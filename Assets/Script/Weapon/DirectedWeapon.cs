using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedWeapon : UnitWeapon
{
    public UnitBullet bulletType = null;
    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitBullet> pool = null;

    List<IObserver> _observers = new List<IObserver>();

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

    public override bool Fire(bool a)
    {
        if (a != false)
        {
            Shoot();
            Debug.Log("xd");
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
