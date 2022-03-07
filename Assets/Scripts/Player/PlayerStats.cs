using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField] private List<GameObject> boardUnits;
    [SerializeField] private List<GameObject> benchUnits;

    [SerializeField] private int[] tierCounter = new int[5]; // unit tier tracker

    [SerializeField] private int boardCounter; // 
    [SerializeField] private int benchCounter; //  replace these!

    [SerializeField] private int currentXP;
    [SerializeField] private int gold;
    [SerializeField] private int playerLevel;
    [SerializeField] private int winStreak;
    [SerializeField] private int loseStreak;

    // capped components
    [SerializeField] private int playerBoardCap;
    [SerializeField] private int playerBenchCap;
    [SerializeField] private int playerSupplyCap;
    [SerializeField] private int xpCap;
    [SerializeField] private const int MAXLEVEL = 11;

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
        gold = 0;
        benchCounter = 0;
        playerSupplyCap = 20;
        playerLevel = 9;
        currentXP = 0;
        SetGold(GameManager.instance.playerGold);

        UIManager.instance.currentXPText.text = currentXP.ToString();
        UIManager.instance.maxXPText.text = xpCap.ToString();
        UIManager.instance.supplyText.text = "Supply: 0/" + playerSupplyCap.ToString();
    }

    public void TierTracker(int tier, int i) // i is for increment/decrement
    {
        tierCounter[tier - 1] += i;
    }

    #region sets
    public void LevelUp()
    {
        if (playerLevel < MAXLEVEL)
        {
            playerLevel += 1;
            Debug.Log("Leveled up!");
            currentXP = 0;

            // xpCap = GameManager.instance.levelReq[playerLevel];
            xpCap = GameManager.instance.GetXPCap();
            playerSupplyCap += GameManager.instance.supplyIncrease;          
            UIManager.instance.supplyText.text = "Supply: 0/" + PlayerStats.instance.GetSupplyCap().ToString();
        }
    }

    public void SetGold(int g)
    {
        gold += g;
        UIManager.instance.goldText.text = "Gold: " + gold.ToString();
    }

    public void SetXP(int x)
    {
        currentXP += x;
        if (currentXP >= xpCap)        
            LevelUp();
             
        UIManager.instance.currentXPText.text = currentXP.ToString();
        UIManager.instance.maxXPText.text = xpCap.ToString();
    }

    public void SetSupply(int s)
    {
        playerSupplyCap += s;
        UIManager.instance.supplyText.text = "Supply: " + playerSupplyCap.ToString() + " / " + playerSupplyCap.ToString();
    }

    public void SetBenchCounter(int i)
    {
        benchCounter += i;
        UIManager.instance.benchCounterText.text = "Bench: " + benchCounter.ToString();
    }

    public void SetBoardCounter(int i)
    {
        boardCounter += i;
        UIManager.instance.boardCounterText.text = "Board: " + boardCounter.ToString();
    }

    public void SetXPCap(int i)
    {
        xpCap = i;
    }
    #endregion

    #region gets
    public int GetPlayerLevel() { return playerLevel; }
    public int GetSupplyCap() { return playerSupplyCap; }
    public int GetGold() { return gold; }
    public int GetXP() { return currentXP; }
    public int GetBenchCount() { return benchUnits.Count; }
    public int GetUnitCount() { return benchUnits.Count + boardUnits.Count; }
    public int GetBoardCount() { return boardUnits.Count; }
    public void AddBoardUnit(GameObject go) { boardUnits.Add(go); }
    public void RemoveBoardUnit(GameObject go) { boardUnits.Remove(go); }
    #endregion
}
