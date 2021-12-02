using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller
{
    Model _model = null;
    JoyController _myStick = null;
    Action changeControls;

    public Controller(Model model, JoyController myStick)
    {
        _model = model;
        _myStick = myStick;
        changeControls = NormalControls;
    }
    public void OnUpdate()
    {
        changeControls();
    }
    public void NormalControls()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var a = Input.GetButton("Fire1");

        //Input PC//
        if (h != 0 || v != 0)
            _model.Movement(h, v);

        if (a != false)
            _model.Shoot();

        if (Input.GetKeyDown(KeyCode.Escape))
            changeControls = PauseControls;

        //Input ANDROID//
        if ((h != _myStick.InputHorizontal(h) || v != _myStick.InputVertical(v)) && _myStick.OnDragStick != null)
            _model.Movement(_myStick.InputHorizontal(h), _myStick.InputVertical(v));

        if (_myStick.InputShoot(a) != false)
            _model.Shoot();

    }

    public void PauseControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeControls = NormalControls;
        }
    }

}
