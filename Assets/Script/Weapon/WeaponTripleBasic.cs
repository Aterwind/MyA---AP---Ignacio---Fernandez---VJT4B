using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleBasic : UnitWeapon
{
    public UnitBullet bulletType = null;
    [SerializeField] private float startAngle = 0;
    [SerializeField] private float endAngle = 0;
    [SerializeField] private float radius = 0;

    private float angleStep = 0;
    private float angle = 0;

    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitBullet> pool = null;

    void Start()
    {
        _maxBullet = spawnList.Count;
        pool = new ObjectPool<UnitBullet>(BulletReturn, bulletType.TurnOn, bulletType.TurnOff, _stock);
    }

    protected override void Shoot()
    {
        if (Time.time >= _nextBullet)
        {
            angleStep = (endAngle - startAngle) / _maxBullet;
            angle = (startAngle);

            for (int i = 0; i < _maxBullet; i++)
            {
                float bDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / radius);
                float bDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / radius);

                Vector3 bMoveVector = new Vector3(bDirX, bDirY, 0);
                Vector3 bulDir = (bMoveVector - transform.position).normalized;

                bulletType = pool.GetObject();
                bulletType.transform.position = spawnList[i].transform.position + bulDir;
                bulletType.transform.forward = spawnList[i].transform.forward + bulDir;
                bulletType.BackStock = pool.ReturnObject;

               angle += angleStep;
            }

            _nextBullet = Time.time + _attackBulletRate / _divideAttack;
        }
    }

    public override bool Fire(bool a)
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
