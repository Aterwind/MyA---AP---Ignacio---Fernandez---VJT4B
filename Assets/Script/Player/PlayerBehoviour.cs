using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehoviour : Unit, IDamageable , IReceiveHP
{
    private void Awake()
    {
        _model = new Model(_hp,_maxHp, _speed, transform);
        _controller = new Controller(_model, _myStick);
        _view = new View();

        //Suscribe de View
        _model.OnGetDmg += _view.Damage;
        _model.OnDeath += _view.Death;
        _model.OnGetHp += _view.Receive;
        _model.OnGetmaxHp += _view.ChangeMaxHP;
    }

    public void Start()
    {
        _myStick.OnDragStick += _model.Movement;
        _myStick.OnEndDragStick += _model.Movement;
    }

    private void Update()
    {
        _controller.OnUpdate();
    }

}
