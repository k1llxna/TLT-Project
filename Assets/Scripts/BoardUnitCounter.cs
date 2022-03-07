using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUnitCounter : MonoBehaviour
{
    public static BoardUnitCounter instance;

    [Header("Count of active units on the board")]
    public int totalUnits;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }
}
