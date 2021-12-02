using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitWeapon : MonoBehaviour
{
    [SerializeField] protected int _stock = 0;
    protected int _maxBullet = 0;

    [SerializeField] protected float _attackBulletRate = 0;
    protected float _divideAttack = 2;
    protected float _nextBullet = 0;

    protected abstract void Shoot(); //Dispara la bala
    public abstract void Fire();

 
}
