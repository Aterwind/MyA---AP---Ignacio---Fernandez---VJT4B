using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerBehoviour : MonoBehaviour,IDamageable, IReceiveHP,ICollectible, IObservable
{
    [SerializeField] private float _maxHp = 0;
    [SerializeField] private float _speed = 0;
    private float _hp = 0;

    [SerializeField] private JoyController _myStick = null;
    [SerializeField] private WeaponManager _weaponManager = null;
    [SerializeField] private UnitWeapon _weapon = null;

    private Model _model = null;
    private Controller _controller = null;
    private View _view = null;

    List<IObserver> _observers = new List<IObserver>();

    private void Awake()
    {
        _weapon = _weaponManager.GetWeapon(Type.WeaponBasic);
        _model = new Model(_hp,_maxHp, _speed, transform, _weapon);
        _controller = new Controller(_model, _myStick);
        _view = new View(_model);

    }
    public void Start()
    {
        _myStick.OnDragStick += _model.Movement;
        _myStick.OnEndDragStick += _model.Movement;
        _model.SetHp(_hp,_maxHp);
    }
    private void Update()
    {
        _controller.OnUpdate();
    }

    #region Status Changes
    public void TakeDamage(float dmg)
    {
        _model.TakeDamage(dmg);
    }
    public void ReceiveHP(float hp)
    {
        _model.ReceiveHP(hp);
    }
    public void ChangeMaxHp(float maxHp)
    {
        _model.ChangeMaxHP(maxHp);
    }
    public void ChangeWeapon(int i)
    {
        _weapon = _weaponManager.GetWeapon((Type)i);
        _model.IndexWeapon(_weapon);
    }
    #endregion

    #region OBSERVER
    public void Subscribe(IObserver obs)
    {
        if (!_observers.Contains(obs))
            _observers.Add(obs);
    }

    public void UnSubscribe(IObserver obs)
    {
        if (_observers.Contains(obs))
            _observers.Remove(obs);
    }

    public void NotifyToObservers(string action)
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers[i].Notify(action);
        }
    }
    #endregion
}
