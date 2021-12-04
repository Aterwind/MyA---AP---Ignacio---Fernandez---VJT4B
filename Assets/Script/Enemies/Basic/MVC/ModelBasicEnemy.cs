using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelBasicEnemy
{
    float _hp;
    float _maxHp;
    Transform _myTransform;
    UnitEnemies _enemy;
    Action<UnitEnemies> _backStock;

    IEnemyAdvance _currentStrategy;
    IEnemyAdvance[] _strategy;
    public event Action OnDeathEnemy;

    public ModelBasicEnemy(float hp, float maxHp, Transform myTransform, 
        IEnemyAdvance currentStrategy, IEnemyAdvance[] strategy, Action<UnitEnemies> backStock, UnitEnemies enemy)
    {
        _hp = hp;
        _maxHp = maxHp;
        _myTransform = myTransform;
        _currentStrategy = currentStrategy;
        _strategy = strategy;
        _backStock = backStock;
        _enemy = enemy;
    }
    public void OnStart()
    {
        _strategy[0] = new EnemyBasicAdvance(_myTransform);
        _currentStrategy = _strategy[0];
    }

    public void Move()
    {
        if (_currentStrategy != null)
            _currentStrategy.EnemyAdvance();
    }

}
