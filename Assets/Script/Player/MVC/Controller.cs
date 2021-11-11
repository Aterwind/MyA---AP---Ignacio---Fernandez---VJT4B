using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller
{
    Model _model = null;
    JoyController _myStick = null;
    ListWeapon _myWeapon = null;

    Action changeControls;

    public Controller(Model model, JoyController myStick, ListWeapon myWeapon)
    {
        _model = model;
        _myStick = myStick;
        _myWeapon = myWeapon;

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

        if (h != 0 || v != 0)
            _model.Movement(h, v);

        if ((h != _myStick.InputHorizontal(h) || v != _myStick.InputVertical(v)) && _myStick.OnDragStick != null)
            _model.Movement(_myStick.InputHorizontal(h), _myStick.InputVertical(v));

        if (_myWeapon.Fire(a) != false)
            _myWeapon.Fire(a);

        if (_myStick.InputShoot(a) != false)
            _myWeapon.Fire(_myStick.InputShoot(a));

        if (Input.GetKeyDown(KeyCode.Escape))
            changeControls = PauseControls;
    }

    public void PauseControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeControls = NormalControls;
        }
    }

}
