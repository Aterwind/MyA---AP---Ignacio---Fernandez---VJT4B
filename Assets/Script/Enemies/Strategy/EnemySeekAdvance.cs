using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySeekAdvance : IEnemyAdvance
{
    Transform _transform;
    CapsuleCollider _targetCollider;
    List<GameObject> _listTarget = new List<GameObject>();

    Vector3 _steering;
    Vector3 _desired;
    Vector3 _velocity;
    Vector3 _targetSave;

    Action<UnitEnemies> _backStock;
    UnitEnemies _unitEnemies;

    public EnemySeekAdvance(Transform transform, CapsuleCollider targetCollider,
        List<GameObject> listTarget, Vector3 sterring,Vector3 desired, Vector3 velocity, Vector3 targetSave, 
        UnitEnemies unitEnemies, Action<UnitEnemies> backStock)
    {
        _transform = transform;
        _targetCollider = targetCollider;
        _listTarget = listTarget;
        _steering = sterring;
        _desired = desired;
        _velocity = velocity;
        _targetSave = targetSave;
        _unitEnemies = unitEnemies;
        _backStock = backStock;
    }

    public void EnemyAdvance()
    {
        if (_listTarget.Count >= 1)
        {
            _transform.position += _velocity * Time.deltaTime;
            _transform.forward = _velocity.normalized;
            _targetSave = _listTarget[0].transform.position - _transform.position;
            ApplyForce(Seek());

            if (_targetSave.magnitude < 1)
            {
                Debug.Log("estoy aca");
                _listTarget.Clear();
                _backStock.Invoke(_unitEnemies);
            }
        }
    }

    Vector3 Seek()
    {
        _desired = _listTarget[0].transform.position - _transform.position;
        _desired.Normalize();
        _desired *= FlyweightPointer.EnemySeek.speed;
        _desired.z = 0;

        return SterringFunc();
    }

    Vector3 SterringFunc()
    {
        _steering = _desired - _velocity;
        return _steering;
    }

    void ApplyForce(Vector3 Force)
    {
        _velocity += Force;
        _velocity = Vector3.ClampMagnitude(_velocity, FlyweightPointer.EnemySeek.speed);
    }
}
