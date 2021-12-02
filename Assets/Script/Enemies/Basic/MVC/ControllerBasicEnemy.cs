using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerBasicEnemy
{
    ModelBasicEnemy _model = null;
    Action _status;
    public ControllerBasicEnemy(ModelBasicEnemy model)
    {
        _model = model;
        _status = NormalControls;
    }
    public void OnUpdate()
    {
        _status();
    }
    public void NormalControls()
    {
        _model.Move();
    }

}
