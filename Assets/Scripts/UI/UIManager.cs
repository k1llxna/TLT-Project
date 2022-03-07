using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this class made just to separate the UI gameobjects from other scripts from inspector lol
public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    public Text goldText;
    public Text supplyText;
    public Text benchCounterText;
    public Text boardCounterText;
    public Text currentXPText;
    public Text maxXPText;
    private Text[] levelOddsText;

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
        UpdateUIOdds();
    }

    public void UpdateUIOdds()
    {
        GameObject temp = GameObject.Find("T1");
        temp.GetComponent<Text>().text = (ButtonLibrary.instance.GetDropRate()[PlayerStats.instance.GetPlayerLevel(), 0]).ToString();
        temp = GameObject.Find("T2");
        temp.GetComponent<Text>().text = (ButtonLibrary.instance.GetDropRate()[PlayerStats.instance.GetPlayerLevel(), 1]).ToString();

        temp = GameObject.Find("T3");
        temp.GetComponent<Text>().text = (ButtonLibrary.instance.GetDropRate()[PlayerStats.instance.GetPlayerLevel(), 2]).ToString();

        temp = GameObject.Find("T4");
        temp.GetComponent<Text>().text = (ButtonLibrary.instance.GetDropRate()[PlayerStats.instance.GetPlayerLevel(), 3]).ToString();

        temp = GameObject.Find("T5");
        temp.GetComponent<Text>().text = (ButtonLibrary.instance.GetDropRate()[PlayerStats.instance.GetPlayerLevel(), 4]).ToString();
    }

}
