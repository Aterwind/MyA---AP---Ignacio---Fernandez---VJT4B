using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitBullet:MonoBehaviour, ITurnBase<UnitBullet>
{
    [SerializeField] protected float speed = 0;
    [SerializeField] protected Transform _transform;
    public Action<UnitBullet> BackStock;

    protected IBulletAdvance _currentStrategy = null;
    protected IBulletAdvance[] _strategy = new IBulletAdvance[2];

    protected Vector3 _steering;
    protected Vector3 _desired;
    protected Vector3 _velocity;

    public void TurnOff(UnitBullet b)
    {
        b.gameObject.SetActive(false);
    }
    public void TurnOn(UnitBullet b)
    {
        b.gameObject.SetActive(true);
    }
}
