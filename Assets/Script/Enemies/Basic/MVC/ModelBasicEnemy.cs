using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBasicEnemy
{
    float _hp;
    float _maxHp;
    Transform _myTransform;
    IEnemyAdvance _currentStrategy;
    IEnemyAdvance[] _strategy;

    public ModelBasicEnemy(float hp, float maxHp, Transform myTransform, 
        IEnemyAdvance currentStrategy, IEnemyAdvance[] strategy)
    {
        _hp = hp;
        _maxHp = maxHp;
        _myTransform = myTransform;
        _currentStrategy = currentStrategy;
        _strategy = strategy;

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
