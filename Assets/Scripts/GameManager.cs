using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // set rules here
    [Header("Set Rules Here")]


    [Header("Bench Components")]
    public int benchSize;
    public int benchXSpacing;
    public int benchZSpacing;
    // board size
    // bench size

    [Header("Game Rules")]
    public float prepPhaseTimer;
    public float combatPhaseTimer;
    public float overtimePhaseTimer;
    public float delayPhaseTimer;

    public int buyRerollCost;
    public int buyXPCost;

    [Header("Defense Components")]
    public List<GameObject> enemiesRemaining = new List<GameObject>(); // from the waves


    [Header("Player Components")]
    public int playerGold;
    public int playerHP;
    public int playerXP; // current xp

    public int maxBoardSupply;
    public int maxBenchSupply;
    public int playerMaxSupply;
    public int playerLevel;
    public int xpIncrement;
    public int supplyIncrease;


    public static int[] levelReq;
    // items?
    // 

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ButtonLibrary.instance.InitializeDropRates();

        // player components
        InitializeLevelReq();
        UIManager.instance.UpdateUIOdds();

        // begin game/ game loop
        StartCoroutine(PhaseManager.instance.PrepPhase(prepPhaseTimer));
    }

    void Update() // input manager!!! (UPDATES EVERYTHING EXCEPT UNITS)
    {
        // cam controls
        if (Input.GetKeyDown(KeyCode.E))
            RTSCam.instance.BoardCycle(0);
        if (Input.GetKeyDown(KeyCode.Q))
            RTSCam.instance.BoardCycle(1);
        if (Input.GetKeyDown(KeyCode.Space))
            RTSCam.instance.ReturnToBoard();

        RTSCam.instance.UpdateCam();

        // shop hotkeys TEMPORARY!
        if (Input.GetKeyDown(KeyCode.F))
            Shop.instance.BuyXP();
        if (Input.GetKeyDown(KeyCode.R))
            Shop.instance.RollCheck();

        if (Input.GetMouseButtonDown(0))
            StartCoroutine(BuildManager.instance.MouseDown());

        if (Input.GetMouseButtonUp(0))
            if (BuildManager.instance.heldUnit != null)
                StartCoroutine(BuildManager.instance.MouseUp());
    }

    public void InitializeLevelReq()
    {
        levelReq = new int[11];

        levelReq[0] = 0; // lvl 0, there is no lvl 0  nor lvl 1 lol
        levelReq[1] = 0;
        levelReq[2] = 2;
        levelReq[3] = 6;
        levelReq[4] = 10;
        levelReq[5] = 20;
        levelReq[6] = 36;
        levelReq[7] = 56;
        levelReq[8] = 80;
        levelReq[9] = 100;
        levelReq[10] = 130; // arbitrary

        PlayerStats.instance.SetXPCap(levelReq[PlayerStats.instance.GetPlayerLevel()]);
    }

    public int GetXPCap() { return levelReq[PlayerStats.instance.GetPlayerLevel()]; }


    // boards 2 3 4?
}
