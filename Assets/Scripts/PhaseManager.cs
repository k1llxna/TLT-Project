using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PhaseManager : MonoBehaviour
{
    public static PhaseManager instance;

    [SerializeField] private Slider slider;
    [SerializeField] private Transform playerBoard; //, board2, board3, board4;
    [SerializeField] private int currentRound;
    [SerializeField] private int currentStage;

    public enum Phase { Prep, Combat, Overtime, Leak, LastStand }
    public Phase phase;

    void Awake()
    {
        if (instance!= null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        slider = GameObject.Find("Bar").GetComponent<Slider>();
        playerBoard = GameObject.Find("_Board1Blocks").transform;

        currentRound = 1;
        currentStage = 1;
    }

    private void PrepareRound()
    {
        if (currentRound > 0)
        {
            // give player a free roll, 2 XP & ECON
            PlayerStats.instance.SetXP(2);
            PlayerStats.instance.SetGold(2);
            //PlayerStats.instance.AddGold(2); SET ECON
            Shop.instance.Reroll();

            // set next opponent
            // switch (round)
        }
    }

    public IEnumerator PrepPhase(float timeLength_)
    {
        PrepareRound();

        while (slider.value < slider.maxValue)
        {
            // reposition all units to origin hex (if not round 1) (DONT KILL UNTIS!!)
            //setup specific round (enemy)

            slider.maxValue = timeLength_;
            slider.value += Time.deltaTime * timeLength_ / slider.maxValue;

            yield return null; // wait
        }
         
        slider.value = 0;
        StartCoroutine(CombatPhase(GameManager.instance.combatPhaseTimer));
        yield break;
    }

    public IEnumerator CombatPhase(float timeLength_)
    {
        // dequip held unit if there is
        if (BuildManager.instance.GetStoredHex() != null && BuildManager.instance.GetStoredHex().GetIsBenchHex() == false)
        {
            BuildManager.instance.ResetPos();
            Shop.instance.ToggleShop(true);
            Shop.instance.ToggleSell(false);
        }

        // turn off board interaction
        ToggleBoardHexes(false);

        while (slider.value < slider.maxValue)
        {
            //setup specific round (enemy)
            slider.maxValue = timeLength_;
            slider.value += Time.deltaTime * timeLength_ / slider.maxValue;

            yield return null; // wait
        }
        slider.value = 0;
        currentRound += 1;

       // if (PlayerStats.instance.GetBoardCount() > 1 && EnemyPlayer.instance.enemyUnits.Count > 1)
         //   StartCoroutine(OvertimePhase(10));

        if (PlayerStats.instance.GetBoardCount() == 0 && EnemyPlayer.instance.enemyUnits.Count > 0)
        {
            StartCoroutine(LeakPhase());
            yield break;
        } // or add player units to path

       // StartCoroutine(PrepPhase(GameManager.instance.prepPhaseTimer)); 
       
    }
    public IEnumerator OvertimePhase(float timeLength_)
    {
        // add 2-3x speed & dmg to all units (TEMPORARY BUFF!!)

        while (slider.value < slider.maxValue)
        {
            Debug.Log("In Overtime Phase");

            //setup specific round (enemy)
            slider.maxValue = timeLength_;
            slider.value += Time.deltaTime * timeLength_ / slider.maxValue;

            yield return null; // wait
        }
        slider.value = 0;
       // StartCoroutine(PrepPhase(GameManager.instance.prepPhaseTimer));
    }

    public IEnumerator LeakPhase()
    {
        // check every player unit if it done walking
        while (EnemyPlayer.instance.enemyUnits.Count > 0)
        {
            // enemy check is already done since its in sandbox
            foreach (Transform go in GameObject.Find("Sandbox").transform) {
                StartCoroutine(go.gameObject.GetComponent<UnitMovement>().Walk());
            }

            // if all enemie done leak then end phase
            if (EnemyPlayer.instance.unitCompletedWaypoints == EnemyPlayer.instance.enemyUnits.Count)
            {
                StartCoroutine(BossPhase());
                yield break;
            }
            yield return null; // wait
        }
        EnemyPlayer.instance.unitCompletedWaypoints = 0; // reset waypoint counter
        ToggleBoardHexes(true);
        yield break;
    }
    public IEnumerator BossPhase()
    {
        Debug.Log("qwer");
        yield return null;
    }

    // turn off all board colliders
    public void ToggleBoardHexes(bool b)
    {
        if (b == true) // turn on
        {
            foreach (Transform i in playerBoard)
            {
                i.gameObject.GetComponent<Hex>().bc.enabled = true;
            }
            //foreach (Transform i in board2)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = true;
            //}
            //foreach (Transform i in board3)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = true;
            //}
            //foreach (Transform i in board4)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = true;
            //}
        }
        else // off
        {
            foreach (Transform i in playerBoard)
            {
                i.gameObject.GetComponent<Hex>().bc.enabled = false;
            }
            //foreach (Transform i in board2)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = false;
            //}
            //foreach (Transform i in board3)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = false;
            //}
            //foreach (Transform i in board4)
            //{
            //    i.gameObject.GetComponent<Hex>().bc.enabled = false;
            //}
        }
    }

    public bool CheckPhase(int i)
    {
        switch (i) {
            case 0:
                if (phase == Phase.Prep)
                    return true;
                break;
            case 1:
                if (phase == Phase.Combat)
                    return true;
                break;
            case 2:
                if (phase == Phase.Overtime)
                    return true;
                break;
            case 3:
                if (phase == Phase.Leak)
                    return true;
                break;
            case 4:
                if (phase == Phase.LastStand)
                    return true;
                break;

            default:
                Debug.LogError("Phase Check Error");
                return false;

        }
        return false;
    }
    public int GetCurrentRound() { return currentRound; }
    public int GetCurrentStage() { return currentStage; }
}
