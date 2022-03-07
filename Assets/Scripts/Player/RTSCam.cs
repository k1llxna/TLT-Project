using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCam : MonoBehaviour
{
    public static RTSCam instance;

    [SerializeField] private float speed = 0.03f;
    [SerializeField] private float zoomSpeed = 10.0f;
    [SerializeField] private float rotSpeed;

    [SerializeField] private float maxHeight = 40f;
    [SerializeField] private float minHeight = 4f;

    [SerializeField] private Vector2 p1;
    [SerializeField] private Vector2 p2;

    [SerializeField] private Transform scoutPos;
    [SerializeField] private int scoutCounter;

    [SerializeField] private float hsp;
    [SerializeField] private float vsp;
    [SerializeField] private float scrollSp;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        scoutPos = GameObject.Find("Pos1").transform;
        scoutCounter = 1;
    }

    public void UpdateCam()
    {

        hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        vsp = transform.position.y * speed * Input.GetAxis("Vertical");
        scrollSp = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        // prevent overshooting/clipping
        if ((transform.position.y >= maxHeight) && (scrollSp > 0))
        { // check exceeding min/max
            scrollSp = 0;
        }
        else if ((transform.position.y <= minHeight) && (scrollSp < 0))
        {
            scrollSp = 0;
        }

        if ((transform.position.y + scrollSp) > maxHeight) 
        {
            scrollSp = maxHeight - transform.position.y;
        }
        else if ((transform.position.y + scrollSp) < minHeight)
        {
            scrollSp = minHeight - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollSp, 0); // y move
        Vector3 lateralMove = hsp * transform.right; // left right move
        Vector3 forwardMove = transform.forward; // "forward" move (negate cam moving forward dir face
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;
    }

    public void BoardCycle(int i)
    {
        if (i == 0) // E
        {
            scoutCounter += 1;
            if (scoutCounter > 4)
                scoutCounter = 1;
        }
        else // Q
        {
            scoutCounter -= 1;
            if (scoutCounter < 1)
                scoutCounter = 4;
        }

        this.gameObject.transform.position = GameObject.Find("Pos" + scoutCounter).transform.position;
        this.gameObject.transform.rotation = GameObject.Find("Pos" + scoutCounter).transform.rotation;
    }

    public void ReturnToBoard() // SPACE
    {
        this.gameObject.transform.position = GameObject.Find("Pos1").transform.position;
        this.gameObject.transform.rotation = GameObject.Find("Pos1").transform.rotation;
    }
}

/* garbage
 // /if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    speed = 0.06f;
        //    zoomSpeed = 20.0f;
        //}
        //else
        //{
        //    speed = 0.035f;
        //    zoomSpeed = 10.0f;
        //}
        void GetCameraRotation()
    {
        if (Input.GetMouseButtonDown(2))
        {
            p1 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotSpeed;
            float dy = (p2 - p1).y * rotSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0)); // y rotation
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));

            p1 = p2;
        }
    }
 */
