using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLibrary : MonoBehaviour
{
    public static ButtonLibrary instance;
     
    public GameObject[] t1Buttons;
    public GameObject[] t2Buttons;
    public GameObject[] t3Buttons;
    public GameObject[] t4Buttons;
    public GameObject[] t5Buttons;

    public static int[,] dropRate = new int[11, 5];

    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public void CreateButton()
    {
        float temp = Random.Range(0, 100); // used for determining the tier
        int rnd;

        // go through button slots in reverse
        // check rng for tier (PRIO IS GIVEN TO HIGHEST TIER FIRST)
        //Debug.Log(tier);  
        int r1 =      dropRate[PlayerStats.instance.GetPlayerLevel(), 0];
        int r2 = r1 + dropRate[PlayerStats.instance.GetPlayerLevel(), 1];
        int r3 = r2 + dropRate[PlayerStats.instance.GetPlayerLevel(), 2];
        int r4 = r3 + dropRate[PlayerStats.instance.GetPlayerLevel(), 3];
        int r5 = r4 + dropRate[PlayerStats.instance.GetPlayerLevel(), 4];

        // if temp = droprate then select that tier
        if (temp < r1) // 1
        {
            rnd = Random.Range(0, t1Buttons.Length);
            Instantiate(t1Buttons[rnd], transform.position, transform.rotation, Shop.instance.GetButtonList());
            return;
        }
        else if (temp >= r1 && temp < r2) // 2
        {
            rnd = Random.Range(0, t2Buttons.Length);
            Instantiate(t2Buttons[rnd], transform.position, transform.rotation, Shop.instance.GetButtonList());
            return;
        }
        else if (temp >= r2 && temp < r3) // 3
        {
            rnd = Random.Range(0, t3Buttons.Length);
            Instantiate(t3Buttons[rnd], transform.position, transform.rotation, Shop.instance.GetButtonList());
            return;
        }
        else if (temp >= r3 && temp < r4) // 4
        {
            rnd = Random.Range(0, t4Buttons.Length);
            Instantiate(t4Buttons[rnd], transform.position, transform.rotation, Shop.instance.GetButtonList());
            return;
        }
        else if (temp >= r4) // 5
        {
            rnd = Random.Range(0, t5Buttons.Length);
            Instantiate(t5Buttons[rnd], transform.position, transform.rotation, Shop.instance.GetButtonList());
            return;
        }
    }

    public void InitializeDropRates()
    {
        dropRate = new int[11, 5]; // X = LEVELS Y = TIER PERCENTAGE

        // lvl1
        dropRate[0, 0] = 100;
        dropRate[0, 1] = 0;
        dropRate[0, 2] = 0;
        dropRate[0, 3] = 0;
        dropRate[0, 4] = 0;

        // lvl2
        dropRate[1, 0] = 100;
        dropRate[1, 1] = 0;
        dropRate[1, 2] = 0;
        dropRate[1, 3] = 0;
        dropRate[1, 4] = 0;

        // lvl3
        dropRate[2, 0] = 75;
        dropRate[2, 1] = 25;
        dropRate[2, 2] = 0;
        dropRate[2, 3] = 0;
        dropRate[2, 4] = 0;

        // lvl4
        dropRate[3, 0] = 55;
        dropRate[3, 1] = 30;
        dropRate[3, 2] = 15;
        dropRate[3, 3] = 0;
        dropRate[3, 4] = 0;

        // lvl5
        dropRate[4, 0] = 45;
        dropRate[4, 1] = 33;
        dropRate[4, 2] = 20;
        dropRate[4, 3] = 2;
        dropRate[4, 4] = 0;

        // lvl6
        dropRate[5, 0] = 25;
        dropRate[5, 1] = 40;
        dropRate[5, 2] = 30;
        dropRate[5, 3] = 5;
        dropRate[5, 4] = 0;

        // lvl7
        dropRate[6, 0] = 19;
        dropRate[6, 1] = 30;
        dropRate[6, 2] = 35;
        dropRate[6, 3] = 15;
        dropRate[6, 4] = 1;

        // lvl8
        dropRate[7, 0] = 16;
        dropRate[7, 1] = 20;
        dropRate[7, 2] = 35;
        dropRate[7, 3] = 25;
        dropRate[7, 4] = 4;

        // lvl9
        dropRate[8, 0] = 9;
        dropRate[8, 1] = 15;
        dropRate[8, 2] = 30;
        dropRate[8, 3] = 30;
        dropRate[8, 4] = 16;

        // lvl10
        dropRate[9, 0] = 5;
        dropRate[9, 1] = 10;
        dropRate[9, 2] = 20;
        dropRate[9, 3] = 40;
        dropRate[9, 4] = 25;

        // lvl11
        dropRate[10, 0] = 1;
        dropRate[10, 1] = 2;
        dropRate[10, 2] = 12;
        dropRate[10, 3] = 50;
        dropRate[10, 4] = 35;
    }

    public int[,] GetDropRate() { return dropRate; }
}

/*
 { 100, 0  , 0  , 0  , 0  }                  
 { 100, 0  , 0  , 0  , 0  }                  
 { 75 , 25 , 0  , 0  , 0  }                  
 { 55 , 30 , 15 , 0  , 0  }                  
 { 45 , 33 , 20 , 2  , 0  }                  
 { 25 , 40 , 30 , 5  , 0  }                  
 { 19 , 30 , 35 , 15 , 1  }                  
 { 16 , 20 , 35 , 25 , 4  }                  
 { 9  , 15 , 30 , 30 , 16 }                  
 { 5  , 10 , 20 , 40 , 25 }                
 { 1  , 2  , 12 , 50 , 35 }        
*/
