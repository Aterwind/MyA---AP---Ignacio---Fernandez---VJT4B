using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    Model _model;

    public Controller(Model model)
    {
        _model = model;
    }

    public void OnUpdate()
    {

        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");

        if (h != 0 || v != 0)
            _model.Movement(h, v);
    }
}
