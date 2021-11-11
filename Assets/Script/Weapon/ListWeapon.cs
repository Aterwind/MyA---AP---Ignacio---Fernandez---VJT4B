using System.Collections.Generic;
using UnityEngine;
using System;

public class ListWeapon : MonoBehaviour
{
    [SerializeField] private int _stock = 0;
    protected int _maxBullet = 0;

    [SerializeField] private float _attackBulletRate = 0;
    private float _divideAttack = 2;
    private float _nextBullet = 0;

    public UnitBullet bulletType = null;
    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitBullet> pool = null;

    private void Start()
    {
        _maxBullet = spawnList.Count;
        pool = new ObjectPool<UnitBullet>(BulletReturn, bulletType.TurnOn, bulletType.TurnOff, _stock);
    }

    private void Shoot()
    {
        if (Time.time >= _nextBullet)
        {
            for (int i = 0; i < _maxBullet; i++)
            {
                bulletType = pool.GetObject();
                bulletType.transform.position = spawnList[i].transform.position;
                bulletType.transform.forward = spawnList[i].transform.forward;
                bulletType.BackStock = pool.ReturnObject;
            }
            _nextBullet = Time.time + _attackBulletRate / _divideAttack;
        }
    }

    public bool Fire(bool a)
    {
        if (a != false)
        {
            Shoot();
            return true;
        }
        else
            return a;
    }

    public UnitBullet BulletReturn()
    {
        return Instantiate(bulletType);
    }

}
