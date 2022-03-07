using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager instance;



    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
