using System;
using UnityEngine;

public class Model
{
    float _hp;
    float _maxHp;
    float _speed;
    Transform _myTransform;
    UnitWeapon _weapon;

    public event Action<float, float> OnSetHp;
    public event Action<float> OnGetmaxHp;
    public event Action<float> OnGetHp;
    public event Action<float> OnGetDmg;
    public event Action<float> OnDeath;

    public Model(float hp, float maxHp, float speed, Transform transform, UnitWeapon weapon)
    {
        _hp = hp;
        _maxHp = maxHp;
        _hp = _maxHp;
        _speed = speed;
        _myTransform = transform;
        _weapon = weapon;
    }

    public void SetHp(float hp, float maxHp)
    {
        _maxHp = maxHp;
         hp = _maxHp;
        _hp = hp;

        if (OnSetHp != null)
            OnSetHp.Invoke(hp, maxHp);
    }

    public void Movement(float h, float v)
    {
        var dir = _myTransform.up * v;
        dir += _myTransform.right * h;

        if (dir.magnitude > 1)
            _myTransform.position += dir.normalized * _speed * Time.deltaTime;
        else
            _myTransform.position += dir * _speed * Time.deltaTime;
    }

    public void IndexWeapon(UnitWeapon w)
    {
        _weapon = w;
    }

    public void Shoot()
    {
        _weapon.Fire();
    }

    public void ChangeMaxHP(float changeHp)
    {
        _maxHp += changeHp;
        if (OnGetmaxHp != null)
            OnGetmaxHp.Invoke(_maxHp);
    }

    public void ReceiveHP(float hp)
    {
        if (_hp <= _maxHp)
        {
            if(hp > _hp)
            {
                _hp = _maxHp;
                OnGetHp.Invoke(_hp);
            }
            else
            {
                _hp += hp;
                OnGetHp.Invoke(_hp);
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        _hp -= dmg;
        if (_hp <= 0)
        {
            _hp = 0;
            if (OnDeath != null)
                OnDeath.Invoke(_hp);
        }
        else
        {
            if (OnGetDmg != null)
                OnGetDmg.Invoke(_hp);
        }
    }
}
