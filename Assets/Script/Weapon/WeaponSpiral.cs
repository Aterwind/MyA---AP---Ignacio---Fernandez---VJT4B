using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpiral : UnitWeapon
{
    public UnitBullet bulletType = null;
    [SerializeField] private float angle = 0;
    [SerializeField] private float rotation = 0;
    [SerializeField] private float division = 180;
    [SerializeField] private float radius = 180;
    [SerializeField] private bool activeInverse = false;
    private float radiusMax = 360;

    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitBullet> pool = null;
    ObjectPool<UnitBullet> poolInverse = null;

    void Start()
    {
        _maxBullet = spawnList.Count;
        pool = new ObjectPool<UnitBullet>(BulletReturn, bulletType.TurnOn, bulletType.TurnOff, _stock);
        poolInverse = new ObjectPool<UnitBullet>(BulletReturn, bulletType.TurnOn, bulletType.TurnOff, _stock);
    }

    protected override void Shoot()
    {
        if (Time.time >= _nextBullet)
        {
            for (int i = 0; i < _maxBullet; i++)
            {
                float bDirX = transform.position.x + Mathf.Sin(((angle + division * i) * Mathf.PI) / radius);
                float bDirY = transform.position.y + Mathf.Cos(((angle + division * i) * Mathf.PI) / radius);

                Vector3 bMoveVector = new Vector3(bDirX,bDirY, 0);
                Vector3 bulDir = (bMoveVector - transform.position).normalized;

                bulletType = pool.GetObject();
                bulletType.transform.position = spawnList[i].transform.position + bulDir;
                bulletType.transform.forward = bulDir;
                bulletType.BackStock = pool.ReturnObject;
                angle += rotation;

                if(activeInverse != false)
                {
                    float bDirXNegative = transform.position.x + Mathf.Sin(((angle + division * i) * Mathf.PI) / -radius);
                    float bDirNegative = transform.position.y + Mathf.Cos(((angle + division * i) * Mathf.PI) / -radius);

                    Vector3 bMoveVectorNegative = new Vector3(bDirXNegative, bDirNegative, 0);
                    Vector3 bulDirNegative = (bMoveVectorNegative - transform.position).normalized;

                    bulletType = pool.GetObject();
                    bulletType.transform.position = spawnList[i].transform.position + bulDirNegative;
                    bulletType.transform.forward = bulDirNegative;
                    bulletType.BackStock = pool.ReturnObject;
                    angle += rotation;
                }

            }
            angle += rotation;

            if (angle >= radiusMax || angle <= (-radiusMax))
                angle = 0;

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
