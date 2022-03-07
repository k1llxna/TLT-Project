using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonList : MonoBehaviour
{
    public static ButtonList instance;

    public GameObject[] tier1Buttons;
    public GameObject[] tier2Buttons;
    public GameObject[] tier3Buttons;
    public GameObject[] tier4Buttons;
    public GameObject[] tier5Buttons;

    void Awake()
    {
        if (instance!= null)
        {
            return;
        }
        instance = this;
    }
}