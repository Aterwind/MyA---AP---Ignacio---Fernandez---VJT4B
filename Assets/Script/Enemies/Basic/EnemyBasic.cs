using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBasic : UnitEnemies
{
    private ModelBasicEnemy _model = null;
    private ControllerBasicEnemy _controller = null;

    private IEnemyAdvance _currentStrategy = null;
    private IEnemyAdvance[] _strategy = new IEnemyAdvance[1];

    private void Start()
    {
        _model = new ModelBasicEnemy(_hp, _maxHp, _myTransform, _currentStrategy, _strategy, backStock, this);
        _controller = new ControllerBasicEnemy(_model);
        _model.OnStart();
    }
    void Update()
    {
        _controller.OnUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            backStock.Invoke(this);
            EventManager.Trigger("UpdateUIScore", FlyweightPointer.EnemyBasic.enemyTypeScore);
        }

        if(other.gameObject.CompareTag("Bounds"))
        {
            backStock.Invoke(this);
        }
    }

}
