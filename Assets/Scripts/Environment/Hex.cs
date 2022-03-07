using UnityEngine;
using UnityEngine.EventSystems;

public class Hex : MonoBehaviour
{
    public Color hoverColor;

    [SerializeField] private bool isBenchHex;
    [SerializeField] private bool occupied;
    [SerializeField] private GameObject heldUnit;

    [SerializeField] private Renderer rend;
    [SerializeField] private Color startColor;

    [SerializeField] public static int[,] numberID;

    [SerializeField] public BoxCollider bc;

    public int visited = 1;
    public int x = 0;
    public int y = 0;

    public enum hexState
    {
        valid,
        invalid,
        OutOfBounds
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        occupied = false;
        hoverColor = Color.black;
        heldUnit = null;
        bc = GetComponent<BoxCollider>();
       // numberID = new int [ GameManager.instance.boardSize[0], GameManager.instance.boardSize[1]];
    }

    #region methods
    public bool GetIsOccupied() { return occupied; }

    public void SetIsOccupied(bool b) { occupied = b; }

    public GameObject GetHeldUnit() { return heldUnit; }

    public void SetHeldUnit(GameObject g) { heldUnit = g; }

    public bool GetIsBenchHex() { return isBenchHex; }

    public void SetBenchHex() { isBenchHex = true; }

    public int[,] GetNumberID() { return numberID; }
    public void DestroyHeldUnit() {
        DestroyImmediate(heldUnit);
        heldUnit = null;
    }

    public void SetNumberID(int x, int y) 
    {
        //numberID[0] = x;
        //numberID[1] = y;
        //Debug.Log(numberID[x,y]);
    }
    #endregion

    #region mouse
    void OnMouseEnter()
    {   
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    #endregion
}