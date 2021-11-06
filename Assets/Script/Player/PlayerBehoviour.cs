using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehoviour : MonoBehaviour
{
    [SerializeField] private float maxHp = 0;
    [SerializeField] private float hp = 0;
    [SerializeField] private float speed = 0;

    [SerializeField] private JoyController _myStick = null;
    [SerializeField] private Rigidbody _rb = null;

    private Model _model;
    private Controller _controller;
    private View _view;

    private void Awake()
    {
        _model = new Model(hp,maxHp, speed, transform);
        _controller = new Controller(_model);
        _view = new View();

        //Suscribe de View
        _model.OnGetDmg += _view.Damage;
        _model.OnDeath += _view.Death;
    }

    void Start()
    {
        _myStick.OnDragStick += Move;
        _myStick.OnEndDragStick += Move;
    }

    private void Update()
    {
        _controller.OnUpdate();
    }

    public void Move(Vector3 value)
    {
        _rb.velocity += value.normalized * speed;
    }
}
