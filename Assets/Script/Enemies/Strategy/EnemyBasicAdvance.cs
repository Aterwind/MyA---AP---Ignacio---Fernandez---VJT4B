using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAdvance : IEnemyAdvance
{
    Transform _transform;

    public EnemyBasicAdvance(Transform transform)
    {
        _transform = transform;
    }

    public void EnemyAdvance()
    {
        _transform.position += _transform.forward * FlyweightPointer.EnemySeek.speed * Time.deltaTime;
    }
}
