using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitBullet:MonoBehaviour, ITurnBase<UnitBullet>
{
    public Action<UnitBullet> BackStock;
    [SerializeField] protected float speed = 0;

    public void TurnOff(UnitBullet b)
    {
        b.gameObject.SetActive(false);
    }
    public void TurnOn(UnitBullet b)
    {
        b.gameObject.SetActive(true);
    }
}
