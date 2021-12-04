using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronEnemyTwo : IPatronAdvance
{
    Transform _transform;
    int _stock;
    float _distance;
    int _maxRandomListEnemy;
    int _initialPosX;
    int _initialPosY;

    UnitEnemies _enemies;
    List<GameObject> _spawnList = new List<GameObject>();
    ObjectPool<UnitEnemies> _pool;

    public PatronEnemyTwo(Transform transform, int initialPosX, int initialPosY, int stock, float distance, int maxRandomListEnemy, UnitEnemies enemies, List<GameObject> spawnList,
        ObjectPool<UnitEnemies> pool)
    {
        _transform = transform;
        _initialPosX = initialPosX;
        _initialPosY = initialPosY;
        _stock = stock;
        _distance = distance;
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

        for (int i = 0; i < _maxRandomListEnemy; i++)
        {
            Vector3 pos = new Vector3(_initialPosX + _distance * i, _initialPosY, 0);
            _enemies = _pool.GetObject();
            _enemies.transform.position = _spawnList[i].transform.position + pos;
            _enemies.transform.forward = -_spawnList[i].transform.position;
            _enemies.backStock = _pool.ReturnObject;
        }

    }
}
