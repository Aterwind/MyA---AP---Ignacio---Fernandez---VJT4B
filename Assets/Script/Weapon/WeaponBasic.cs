using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponBasic : UnitWeapon
{
    public UnitBullet bulletType = null;
    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitBullet> pool = null;

    private void Start()
    {
        _maxBullet = spawnList.Count;
        pool = new ObjectPool<UnitBullet>(BulletReturn, bulletType.TurnOn, bulletType.TurnOff, _stock);
    }

    protected override void Shoot()
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

    public override void Fire()
    {
       Shoot();
    }

    public UnitBullet BulletReturn()
    {
        return Instantiate(bulletType);
    }

}
