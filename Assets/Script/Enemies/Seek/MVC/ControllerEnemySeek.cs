using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerEnemySeek
{
    ModelEnemySeek _model = null;
    Action _status;
    public ControllerEnemySeek(ModelEnemySeek model)
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
