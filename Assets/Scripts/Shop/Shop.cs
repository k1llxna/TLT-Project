using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    [SerializeField] private Transform buttonList;
    [SerializeField] private GameObject[] buttons; // for rerolling

    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject sellCanvas;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    #region buyunit
    public void BuyCheck(GameObject bluePrint_)
    {
        if (PlayerStats.instance.GetUnitCount() < PlayerStats.instance.GetSupplyCap()) // supply check
        {
            if (PlayerStats.instance.GetGold() >= bluePrint_.gameObject.GetComponent<Unit>().cost)
            { // gold check
                BuyUnit(bluePrint_);                       
            }
            else
            {
                  Debug.Log("Insufficient Gold!");
                  return; // no gold
            }
        }
        else
        {
            Debug.Log("Insufficient Supply!");
            return; // no supply
        }
    }

    // private and public add buy check
    private void BuyUnit(GameObject blueprint)
    {
        // supply check
        // avaliable bench space
        if (PlayerStats.instance.GetBenchCount() < 8) 
        {
            for (int i = 0; i < 8; i++) // 8 = bench count
            {
                Hex t = GameObject.Find("Bench1Blocks").transform.GetChild(i).gameObject.GetComponent<Hex>();
                if (t.GetIsOccupied() == false)
                {
                    t.SetHeldUnit(Instantiate(blueprint, t.transform.position, t.transform.rotation, GameObject.Find("Bench1").transform));
                    t.GetHeldUnit().GetComponent<UnitMovement>().originHex = t;
                   // t.GetHeldUnit().gameObject.transform.SetParent(GameObject.Find("Bench1").transform); //
                    t.SetIsOccupied(true);

                    t.GetHeldUnit().GetComponent<Unit>().unitType = UnitType.player;

                   
                    PlayerStats.instance.SetGold(-blueprint.gameObject.GetComponent<Unit>().cost);
                    PlayerStats.instance.SetSupply(blueprint.gameObject.GetComponent<Unit>().supplyCost);
                    PlayerStats.instance.SetBenchCounter(1);
                    PlayerStats.instance.TierTracker(blueprint.gameObject.GetComponent<Unit>().tier, 1);

                  //  PlayerStats.instance.AddBenchUnit(blueprint.gameObject);
                    return;
                }
            }
            return;
        }

        // if bench is full, place bouight unit on board
        else if (PlayerStats.instance.GetBenchCount() >= 8) // 8* change the 8 to var
        {
            for (int x = 0; x < GameObject.Find("Board1Blocks").transform.childCount; x++)
            {
                    Hex t = GameObject.Find("Board1Blocks").transform.GetChild(x).gameObject.GetComponent<Hex>();
                    if (t.GetIsOccupied() == false)
                    {
                        t.SetHeldUnit(Instantiate(blueprint, t.transform.position, t.transform.rotation));
                        t.GetHeldUnit().GetComponent<UnitMovement>().originHex = t;
                        t.GetHeldUnit().GetComponent<Unit>().unitType = UnitType.player;
                        t.SetIsOccupied(true);

                        PlayerStats.instance.AddBoardUnit(t.GetHeldUnit());
                       // blueprint.transform.SetParent(GameObject.Find("Bench1").transform);
    
                        PlayerStats.instance.SetGold(-blueprint.gameObject.GetComponent<Unit>().cost);
                        PlayerStats.instance.SetSupply(blueprint.gameObject.GetComponent<Unit>().supplyCost);
                        PlayerStats.instance.SetBoardCounter(1); 
                        PlayerStats.instance.TierTracker(blueprint.gameObject.GetComponent<Unit>().tier, 1);
                        PlayerStats.instance.AddBoardUnit(blueprint.gameObject);
                        return;
                    }
            }
            Debug.Log("Error has occured!"); // it should never reach here
            return;
        }     
    }
    #endregion

    #region shopcomponents
    public void RollCheck()
    {
        if (PlayerStats.instance.GetGold() >= GameManager.instance.buyRerollCost)
        {
            Reroll();
            PlayerStats.instance.SetGold(-GameManager.instance.buyRerollCost);
        }
        else
        {
            Debug.Log("No Gold to Roll!");
            return;   
        }
    }

    public void Reroll()
    {     
        // remove existing units in shop
        foreach (Transform child in buttonList)
        {
            GameObject.Destroy(child.gameObject);
        }
        // 1 2 3 4 5
        ButtonLibrary.instance.CreateButton();
        ButtonLibrary.instance.CreateButton();
        ButtonLibrary.instance.CreateButton();
        ButtonLibrary.instance.CreateButton();
        ButtonLibrary.instance.CreateButton();   
    }

    public void ToggleShop(bool b)
    {
        shopCanvas.SetActive(b);
    }

    public void ToggleSell(bool b)
    {
        sellCanvas.SetActive(b);
    }

    public void BuyXP()
    {
        if (PlayerStats.instance.GetGold() > GameManager.instance.buyRerollCost)
        {
            PlayerStats.instance.SetXP(GameManager.instance.xpIncrement);
            PlayerStats.instance.SetGold(-GameManager.instance.buyRerollCost);
        }
    }

    public int GetButtonLength() { return buttons.Length; }

    public Transform GetButtonList() { return buttonList; }
    #endregion
}

/*
 1 Win/Lose	-
2 Win/Lose Streaks	+1 Gold
3 Win/Lose Streaks	+1 Gold
4 Win/Lose Streaks	+2 Gold
5 Win/Lose Streaks~	+3 Gold
     
    0 ~ 9 Gold	-
10 ~ 19 Gold	+1 Gold
20 ~ 29 Gold	+2 Gold
30 ~ 39 Gold	+3 Gold
40 ~ 49 Gold	+4 Gold
50 Gold~	+5 Gold
     */
