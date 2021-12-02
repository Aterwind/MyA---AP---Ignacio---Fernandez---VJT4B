using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletBasicAdvance : IBulletAdvance
{
    float _speed;
    Transform _transform;

    public BulletBasicAdvance(float speed, Transform transform)
    {
        _speed = speed;
        _transform = transform;
    }

    public void BulletAdvance()
    {
        _transform.position += _transform.forward * _speed * Time.deltaTime;
    }
}
