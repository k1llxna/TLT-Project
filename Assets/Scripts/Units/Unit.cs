using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Shop Components")]
    public string unitName;
    public int cost;
    public int sellCost;
    public int supplyCost;
    public int tier; // could be ENUM but idk how to reference elsewhere KEK

    [Header("Unit Components")]
    public UnitType unitType;

    public int maxHP;
    public int currentHP;

    public int armor;
    public int baseArmor;

    public int baseDMG;
    public int atkDMG;

    public int baseRange;
    public int range;

    public float baseMoveSpeed;
    public float moveSpeed;

    public float baseAtkSpeed;
    public float atkSpeed;

    private int manaBar;
    public bool useManaBar;

    Trait[] traits;

    private void Awake()
    {
        unitType = UnitType.none;
    }

    private void Start()
    {
        switch (unitType)
        {
            case UnitType.enemy:
                EnemyPlayer.instance.enemyUnits.Add(this.gameObject);
                break;
        }
    }

    public void SetUnitType(int i)
    {
        switch (i)
        {
            case 0: // playerunit
                unitType = UnitType.player;
                break;
            case 1: // enemy unit
                unitType = UnitType.enemy;
                break;
            case 2: // ally unit
                unitType = UnitType.ally;
                break;
            default: // none
                unitType = UnitType.none;
                break;
        }
    }

    public void DestroyUnit()
    {
        if (gameObject.CompareTag("Enemy")) // add $?
            EnemyPlayer.instance.enemyUnits.Remove(gameObject);
        Destroy(gameObject);
    }

    public void TakeDamage(int d)
    {
        maxHP -= d;

        if (maxHP <= 0)
            DestroyUnit();
    }
}

public enum UnitType
{
    player,
    enemy,
    ally,
    none
}
