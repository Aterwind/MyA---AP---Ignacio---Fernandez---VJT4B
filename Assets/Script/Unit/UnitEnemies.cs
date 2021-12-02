using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitEnemies : MonoBehaviour, ITurnBase<UnitEnemies>
{
    [SerializeField] protected float _maxHp = 0;
    [SerializeField] protected Transform _myTransform = null;
    protected float _hp;
    public Action<UnitEnemies> backStock;

    public void TurnOff(UnitEnemies b)
    {
        b.gameObject.SetActive(false);
    }

    public void TurnOn(UnitEnemies b)
    {
        b.gameObject.SetActive(true);
    }

    public UnitEnemies Enemies()
    {
        return Instantiate(this);
    }
}
