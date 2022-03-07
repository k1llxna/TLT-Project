using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLibrary : MonoBehaviour
{
    public static UnitLibrary instance;

    [Header("ALL Units in the game go HERE!!!")]
    [Header("Unit IDs are index of list")]
    public List<GameObject> units;
    public List<GameObject> obstacles;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public void SpawnUnit(int i) // spawn unit 
    {
        if (units.Count < 1) return; // less than 1 unit in unit library

        int counter = 0;

        foreach (Transform t in GameObject.Find("_Board1Blocks").transform)
        {
            Hex hex = t.gameObject.GetComponent<Hex>();

            counter++;

            if (hex.GetIsOccupied() == true) continue;

            GameObject go = Instantiate(units[i], new Vector3(t.position.x, 1, t.position.z), transform.rotation, GameObject.Find("Sandbox").transform);

            go.GetComponent<UnitMovement>().MoveToNewHex(counter);
            go.GetComponent<Unit>().unitType = UnitType.enemy;
            go.tag = "Enemy";
            go.GetComponent<UnitMovement>().SetWaypoints();
            GameObject.Find("Enemy").gameObject.GetComponent<EnemyPlayer>().enemyUnits.Add(go);
            Debug.Log("Spawned!");
            return;       
        }
    }

    public void DeleteUnit()
    {
        
    }
} 
