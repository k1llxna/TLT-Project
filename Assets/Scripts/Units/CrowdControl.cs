using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControl 
{
    public static CrowdControl instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Knockback(GameObject unit, int knockbackRange)
    {

    }

    public void Knockback(GameObject[] unit, int knockbackRange)
    {

    }

    public void Stun(GameObject unit, float duration)
    {

    }

    public void Stun(GameObject[] unit, float duration)
    {

    }
}
