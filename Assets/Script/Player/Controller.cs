using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    Model _model = null;
    JoyController _myStick = null;

    public Controller(Model model, JoyController myStick)
    {
        _model = model;
        _myStick = myStick;
    }

    public void OnUpdate()
    {
        var v = _myStick.InputVertical();
        var h = _myStick.InputHorizontal();

        if (h != 0 || v != 0)
            _model.Movement(h, v);

        if (_myStick.OnDragStick != null)
            _myStick.OnDragStick(h, v);


    }

}
