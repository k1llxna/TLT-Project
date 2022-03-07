using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // static for PVE only
{
    public static Enemy instance;

    [SerializeField] private int unitCount = 0;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public int GetEnemyUnitCount() { return unitCount; }
}
