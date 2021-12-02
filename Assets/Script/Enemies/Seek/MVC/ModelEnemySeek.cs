using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelEnemySeek
{
    float _hp;
    float _maxHp;
    Transform _myTransform;
    int _indexState;
    CapsuleCollider _targetCollider;

    Vector3 _steering;
    Vector3 _desired;
    Vector3 _velocity;
    Vector3 _targetSave;

    IEnemyAdvance _currentStrategy;
    IEnemyAdvance[] _strategy;

    List<GameObject> _listTarget = new List<GameObject>();

    public ModelEnemySeek(float hp, float maxHp, int indexState, Transform myTransform, 
        IEnemyAdvance currentStrategy, IEnemyAdvance[] strategy, CapsuleCollider targetCollider,
        Vector3 sterring, Vector3 desired, Vector3 velocity, Vector3 targetSave, List<GameObject> listTarget)
    {
        _hp = hp;
        _maxHp = hp;
        _indexState = indexState;
        _myTransform = myTransform;
        _currentStrategy = currentStrategy;
        _strategy = strategy;
        _targetCollider = targetCollider;
        _steering = sterring;
        _desired = desired;
        _velocity = velocity;
        _targetSave = targetSave;
        _listTarget = listTarget;

    }

    public void OnStart()
    {
        _strategy[0] = new EnemyBasicAdvance(_myTransform);
        _strategy[1] = new EnemySeekAdvance(_myTransform, _targetCollider,_listTarget,_steering,_desired,_velocity,_targetSave);
        _currentStrategy = _strategy[_indexState];
    }

    public void Move()
    {
        if (_currentStrategy != null)
            _currentStrategy.EnemyAdvance();

        if (_listTarget.Count >= 1)
            _currentStrategy = _strategy[1];
        else
            _currentStrategy = _strategy[0];
    }
}
