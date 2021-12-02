using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronEnemyOne : IPatronAdvance
{
    Transform _transform;
    int _stock;
    float _distance = 0;
    float _startAngle = 0;
    float _endAngle = 0;
    float _radius = 0;
    float _division = 0;
    float _angleStep = 0;
    float _angle = 0;

    int _maxRandomListEnemy = 0;

    UnitEnemies _enemies;
    List<GameObject> _spawnList = new List<GameObject>();
    ObjectPool<UnitEnemies> _pool;

    public PatronEnemyOne(Transform transform,int stock, float distance, float startAngle, float endAngle, float radius,
        float divison, float angleStep, float angle, int maxRandomListEnemy, UnitEnemies enemies,List<GameObject> spawnList,
        ObjectPool<UnitEnemies> pool)
    {
        _transform = transform;
        _stock = stock;
        _distance = distance;
        _startAngle = startAngle;
        _endAngle = endAngle;
        _radius = radius;
        _division = divison;
        _angleStep = angleStep;
        _angle = angle;
        _maxRandomListEnemy = maxRandomListEnemy;
        _enemies = enemies;
        _spawnList = spawnList;
        _pool = pool;
    }
    public void OnStart()
    {
        _pool = new ObjectPool<UnitEnemies>(_enemies.Enemies, _enemies.TurnOn, _enemies.TurnOff, _stock);
    }

    public void PatronAdvance()
    {
        _angleStep = _endAngle / _maxRandomListEnemy;
        _angle = _startAngle;

        for (int i = 0; i < _maxRandomListEnemy; i++)
        {
            float dirX = _transform.position.x + Mathf.Sin(((_angle + _division * i) * Mathf.PI) / _radius);
            float dirY = _transform.position.y + Mathf.Cos(((_angle + _division * i) * Mathf.PI) / _radius);

            Vector3 moveVector = new Vector3(dirX, dirY, 0);
            Vector3 enemyDir = (moveVector - _transform.position).normalized;

            _enemies = _pool.GetObject();
            _enemies.transform.position = _spawnList[i].transform.position + enemyDir * _distance;
            _enemies.backStock = _pool.ReturnObject;
            _angle += _angleStep;
        }
    }

}
