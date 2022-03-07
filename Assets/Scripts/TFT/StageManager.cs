using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;


    void Awake()
    {
        if (instance != null )
        {
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetEnemies()
    {

    }
}


