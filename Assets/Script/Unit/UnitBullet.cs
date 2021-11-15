using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitBullet:MonoBehaviour, ITurnBase<UnitBullet>
{
    [SerializeField] protected Transform _transform;
    public Action<UnitBullet> BackStock;

    protected IBulletAdvance _currentStrategy = null;
    protected IBulletAdvance[] _strategy = new IBulletAdvance[2];

    public void TurnOff(UnitBullet b)
    {
        b.gameObject.SetActive(false);
    }
    public void TurnOn(UnitBullet b)
    {
        b.gameObject.SetActive(true);
    }
}
