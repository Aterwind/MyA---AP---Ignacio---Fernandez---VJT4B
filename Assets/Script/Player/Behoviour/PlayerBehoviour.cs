using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehoviour : MonoBehaviour,IDamageable, IReceiveHP
{
    [SerializeField] private float _maxHp = 0;
    [SerializeField] private float _speed = 0;
    [SerializeField] private int _indexWeapon = 0;
    private float _hp = 0;

    [SerializeField] private JoyController _myStick = null;
    [SerializeField] private List<UnitWeapon> _myWeapon = new List<UnitWeapon>();

    private Model _model = null;
    private Controller _controller = null;
    private View _view = null;

    private void Awake()
    {
        _model = new Model(_hp,_maxHp, _speed, transform);
        _controller = new Controller(_model, _myStick, _myWeapon[_indexWeapon]);
        _view = new View(_model, _myWeapon[_indexWeapon]);
    }
    public void Start()
    {
        _myStick.OnDragStick += _model.Movement;
        _myStick.OnEndDragStick += _model.Movement;
    }
    public void TakeDamage(float dmg)
    {
        _model.TakeDamage(dmg);
    }
    public void ReceiveHP(float hp)
    {
        _model.ReceiveHP(hp);
    }

    private void Update()
    {
        _controller.OnUpdate();
    }

}
