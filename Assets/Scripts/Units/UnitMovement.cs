using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    Board board;
    public Hex originHex = null; // unit assigned to hex

    [Space(10)]
    [Header("Pathfinding")]
    public bool findDistance = false;

    [SerializeField] private Vector2 startPos = new Vector2(0, 0);
    [SerializeField] private Vector2 targetPos = new Vector2(0, 0);

    [SerializeField] private GameObject target;
    [SerializeField] private int pathCounter;

    public List<GameObject> path = new List<GameObject>();

    [Space(10)]
    [Header("Leak Var")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private int waypointCounter = 0;
    [SerializeField] private bool completedWaypoints = false;

    [Space(10)]
    [Header("Util")]
    public State currentState;
    [SerializeField] private CapsuleCollider bc;

    void Start()
    {
        bc = GetComponent<CapsuleCollider>();
        currentState = State.prep;
    }
    private void Update()
    {


        // prep phase, dont do anything lol
        if (currentState != State.prep) return;

        if (currentState == State.bench) return;

        // post combat phase, walking towards thor
        if (currentState != State.walking) return;

        if (currentState != State.seek) return;

        if (currentState != State.knockedBack) return;

        if (currentState != State.stunned) return;

        if (currentState != State.specialMove) return;

        if (currentState != State.attack) return;

        if (findDistance)
        {

            //Board.instance.SetDistance(); // get the numbers
            //Board.instance.SetPath(); // lsit array

            if (path.Count > 1)
            {
                pathCounter = path.Count;
                StartCoroutine(SeekTarget());
            }
            findDistance = false;
        }

        // if board.enemycount == 0 - tp the board pool
        // (as enemy) walk to board pool
    }

    #region hexplacement  
    public void MoveToNewHex(int i) // for editor
    {
        GameObject go = GameObject.Find("_Board1Blocks").transform.GetChild(i - 1).gameObject;

        // occupied alraedy, swap units
        if (go.GetComponent<Hex>().GetIsOccupied()) 
        {
            SwapHex(originHex, go.GetComponent<Hex>());
            return;
        }

        // clear old hex
        if (originHex)
        {
            originHex.GetComponent<Hex>().SetIsOccupied(false);
            originHex.GetComponent<Hex>().SetHeldUnit(null);
        }

        transform.position = new Vector3(go.transform.position.x, 1, go.transform.position.z);

        originHex = go.GetComponent<Hex>(); // bind unit to hex
        go.GetComponent<Hex>().SetIsOccupied(true); // set hex to occupied
        go.GetComponent<Hex>().SetHeldUnit(this.gameObject);

        // parent to board
        this.gameObject.transform.SetParent(GameObject.Find("Sandbox").transform);

        SetRotation();
    }

    public void MoveToNewHex(Hex oldHex, Hex newHex) // cursor swap, NOT AI
    {
        transform.position = newHex.gameObject.transform.position;
        oldHex.SetHeldUnit(null);
        oldHex.SetIsOccupied(false);
        newHex.SetHeldUnit(BuildManager.instance.heldUnit);
        newHex.SetIsOccupied(true);

        //PlayerStats.instance.AddBoardUnit(newHex.GetHeldUnit());
        //PlayerStats.instance.RemoveBoardUnit(oldHex.GetHeldUnit());

        if (oldHex.GetIsBenchHex() == true & newHex.GetIsBenchHex() == false)
        { // bench to board counter update
            PlayerStats.instance.SetBenchCounter(-1);
            PlayerStats.instance.SetBoardCounter(1);
            PlayerStats.instance.AddBoardUnit(BuildManager.instance.heldUnit);

            // parent to board
            this.gameObject.transform.SetParent(GameObject.Find("Player").transform);
            //this.gameObject.transform.SetParent(GameObject.Find("Board1 " + PhaseManager.instance.GetCurrentStage().ToString() + "-" + PhaseManager.instance.GetCurrentRound().ToString()).transform);
        }
        else if(oldHex.GetIsBenchHex() == false & newHex.GetIsBenchHex() == true)
        { // board to bench counter update
            PlayerStats.instance.SetBenchCounter(1);
            PlayerStats.instance.SetBoardCounter(-1);
            PlayerStats.instance.RemoveBoardUnit(BuildManager.instance.heldUnit.gameObject);

            // parent to bench
            this.gameObject.transform.SetParent(GameObject.Find("PlayerBench").transform);
        }
        originHex = newHex;
    }

    public void SwapHex(Hex oldHex, Hex newHex) // version for swapping units
    {   
        // swap positions
        SetOriginHex(newHex);
        newHex.GetHeldUnit().GetComponent<UnitMovement>().SetOriginHex(oldHex);

        SetRotation();
        newHex.GetHeldUnit().GetComponent<UnitMovement>().SetRotation();

        // assign new origin hex to unit
        originHex = newHex;
        newHex.GetHeldUnit().gameObject.GetComponent<UnitMovement>().originHex = oldHex;

        // assign new units to hex
        GameObject tempHex = oldHex.GetHeldUnit().gameObject;
        oldHex.SetHeldUnit(newHex.GetHeldUnit().gameObject);
        newHex.SetHeldUnit(tempHex);

    } // dont change occupied cuz they both hold units lol

    // set new position and change rotation if needed
    public void SetOriginHex(Hex hex)
    {
        transform.position = new Vector3(hex.gameObject.transform.position.x, hex.gameObject.transform.position.y + 1, hex.gameObject.transform.position.z);
    }

    void SetRotation()
    {
        if (originHex.GetIsBenchHex()) return;

        if (originHex.gameObject.transform.GetSiblingIndex() <= 49)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0); // look downwards
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    #endregion

    #region hexpathfinding
    IEnumerator SeekTarget()
    {
        gameObject.GetComponent<UnitMovement>().currentState = UnitMovement.State.hexSeek;
        while (pathCounter > -1)
        {
            if (Vector3.Distance(transform.position, path[pathCounter - 1].transform.position) < .5f)
            {
                // check enemy range and attack
                if (Vector3.Distance(transform.position, target.transform.position) <= gameObject.GetComponent<Unit>().range)
                    // attack

                    pathCounter--;
                if (pathCounter == 1)
                {
                    yield return null;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, path[pathCounter - 1].transform.position, 2f * Time.deltaTime);
            yield return null;
        }
    }
    #endregion

    #region pathwalking
    public IEnumerator Walk()
    {
        currentState = State.walking;
        while (waypointCounter < waypoints.Count + 1 && currentState == State.walking)
        {
            if (Vector3.Distance(this.transform.position, waypoints[waypointCounter].position) < 1f)
            {
                waypointCounter++;
                if (waypointCounter >= waypoints.Count) 
                {
                    currentState = State.hexSeek;
                    EnemyPlayer.instance.unitCompletedWaypoints++;
                    yield break;
                }
            }
            // move unit
            transform.position = Vector3.MoveTowards(gameObject.transform.position, waypoints[waypointCounter].position, (gameObject.GetComponent<Unit>().moveSpeed) * Time.deltaTime);
            gameObject.transform.LookAt(waypoints[waypointCounter]);
            yield return null;
        }
    }

    public void SetWaypoints()
    {
        foreach (Transform i in GameObject.Find("Waypoint").transform)
        {
            if (i.gameObject.CompareTag("Waypoint"))
                gameObject.GetComponent<UnitMovement>().waypoints.Add(i.transform);
        }
    }
    #endregion

    public void AssignToBoardPool()
    {
        foreach (Hex go in GameObject.Find("BoardPool").GetComponentsInChildren<Hex>())
        {
            if (go)
                if (go.GetIsOccupied() == false)
                {
                    MoveToNewHex(originHex, go);
                }
        }
    }

    #region combat
    private IEnumerator Attack(float atkSpeed)
    {

        yield return null; // wait
    }

    private IEnumerator SpecialMove(float timer)
    {
        currentState = State.specialMove;

        // channel (animation)
        yield return new WaitForSeconds(timer);

    }

    private IEnumerator Stunned(float duration)
    {

        yield return null; // wait
    }

    private IEnumerator Knockback(int distance)
    {
        yield return null; // wait

    }
    #endregion

    #region util
    public void ChangeState(int s)
    {
        switch (s)
        {
            case 0:
                currentState = State.prep;
                break;
            case 1:
                currentState = State.walking;
                break;
            case 2:
                currentState = State.knockedBack;
                break;
            case 3:
                currentState = State.stunned;
                break;
            case 4:
                currentState = State.specialMove;
                break;
            case 5:
                currentState = State.attack;
                break;
            case 6:
                currentState = State.seek;
                break;
            case 7:
                currentState = State.hexSeek;
                break;
            case 8:
                currentState = State.bench;
                break;
        }
    }

    public enum State
    {
        seek,
        hexSeek,
        attack,
        specialMove,
        stunned,
        knockedBack,
        walking,
        prep,
        bench
    }

    public void DestroyUnit()
    {
        originHex.SetHeldUnit(null);
        originHex.SetIsOccupied(false);
        DestroyImmediate(this.gameObject);
    }
    #endregion
}
