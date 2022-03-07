using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    public static EnemyPlayer instance;

    public List<GameObject> enemyUnits;
    public List<GameObject> enemyObstacles;

    public int unitCompletedWaypoints = 0;

    private void Awake()
    {
        if (instance != null) return;

        instance = this;
    }
}
