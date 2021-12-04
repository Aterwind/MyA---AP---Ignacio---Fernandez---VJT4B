using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitColletable : MonoBehaviour, ITurnBase<UnitColletable>
{
    public Action<UnitColletable> backStock;
    public void TurnOff(UnitColletable b)
    {
        b.gameObject.SetActive(false);
    }

    public void TurnOn(UnitColletable b)
    {
        b.gameObject.SetActive(true);
    }
}
