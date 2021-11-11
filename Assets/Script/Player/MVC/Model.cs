﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model
{
    float _hp;
    float _maxHp; 
    float _speed;
    Transform _myTransform;

    public event Action<float> OnGetmaxHp;
    public event Action<float> OnGetHp;
    public event Action<float, float> OnGetDmg;
    public event Action OnDeath;

    public Model(float hp, float maxHp, float speed, Transform transform)
    {
        _hp = hp;
        _maxHp = maxHp;
        _hp = _maxHp;
        _speed = speed;
        _myTransform = transform;
    }

    public void Movement(float h, float v)
    {
        var dir = _myTransform.up * v;
        dir += _myTransform.right * h;

        if(dir.magnitude > 1)
            _myTransform.position += dir.normalized * _speed * Time.deltaTime;
        else
            _myTransform.position += dir * _speed * Time.deltaTime;
    }

    public void ChangeMaxHP(float changeHp)
    {
        _maxHp += changeHp;
        if(OnGetmaxHp != null)
            OnGetmaxHp.Invoke(_maxHp);
    }

    public void ReceiveHP(float hp)
    {
        if (_hp < _maxHp)
        {
            _hp += hp;
            OnGetHp.Invoke(_hp);
        }
    }

    public void TakeDamage(float dmg)
    {
        _hp -= dmg;
        if (_hp <= 0)
        {
            _hp = 0;
            if (OnDeath != null)
                OnDeath.Invoke();
        }
        else
        {
            if (OnGetDmg != null)
                OnGetDmg.Invoke(_hp, _maxHp);
        }
    }
}