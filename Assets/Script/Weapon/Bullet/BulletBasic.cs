﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : UnitBullet
{
    void Start()
    {
        _strategy[0] = new BulletBasicAdvance(speed, _transform);
        _currentStrategy = _strategy[0];
    }

    void Update()
    {
        if (_currentStrategy != null)
            _currentStrategy.EnemyAdvance();
    }

    public void OnTriggerEnter(Collider other)
    {
        BackStock.Invoke(this);
    }
}
