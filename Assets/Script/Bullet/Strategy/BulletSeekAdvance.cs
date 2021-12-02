using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletSeekAdvance : IBulletAdvance
{
    float _speed;
    Transform _transform;
    CapsuleCollider _targetCollider;
    List<GameObject> _listTarget = new List<GameObject>();
    float _timeResetCollider;
    float _distanceBackStock;

    Vector3 _steering;
    Vector3 _desired;
    Vector3 _velocity;
    Vector3 _targetSave;

    Action<UnitBullet> _BackStock;
    UnitBullet _unitBullet;

    public BulletSeekAdvance(float speed, Transform transform, CapsuleCollider targetCollider, 
        List<GameObject> listTarget, float timeResetCollider, float distanceBack, Vector3 sterring,
        Vector3 desired, Vector3 velocity, Vector3 targetSave, UnitBullet unitBullet, Action<UnitBullet> BackStock)
    {
        _speed = speed;
        _transform = transform;
        _targetCollider = targetCollider;
        _listTarget = listTarget;
        _timeResetCollider = timeResetCollider;
        _distanceBackStock = distanceBack;
        _steering = sterring;
        _desired = desired;
        _velocity = velocity;
        _targetSave = targetSave;
        _unitBullet = unitBullet;
        _BackStock = BackStock;

    }

    public void BulletAdvance()
    {
        if(_listTarget.Count >= 1)
        {
            _transform.position += _velocity * Time.deltaTime;
            _transform.forward = _velocity.normalized;
            _targetSave = _listTarget[0].transform.position - _transform.position;

            ApplyForce(Seek());

            if(_targetSave.magnitude < _distanceBackStock)
            {
                _listTarget.Clear();
                _BackStock.Invoke(_unitBullet);
            }
        }
    }

    Vector3 Seek()
    {
        _desired = _listTarget[0].transform.position - _transform.position;
        _desired.Normalize();
        _desired *= _speed;
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
        _velocity = Vector3.ClampMagnitude(_velocity, _speed);
    }

}
