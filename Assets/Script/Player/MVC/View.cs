using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View
{
    public View(Model model)
    {
        model.OnGetDmg += Damage;
        model.OnDeath += Death;
        model.OnGetHp += Receive;
        model.OnGetmaxHp+= ChangeMaxHP;
        model.OnSetHp += HpInitial;
    }

    public void HpInitial(float hp, float maxHp)
    {
        EventManager.Trigger("UpdateUIhp", hp, maxHp);
    }

    public void Receive(float hp)
    {
        EventManager.Trigger("UpdateUIhp", hp, null);
    }

    public void ChangeMaxHP(float maxHp)
    {
        EventManager.Trigger("UpdateUIhp", null , maxHp);
    }

    public void Damage(float hp)
    {
        EventManager.Trigger("UpdateUIhp", hp, null);
    }

    public void Death(float hp)
    {
        EventManager.Trigger("UpdateUIhp", hp, null);
        EventManager.Trigger("ResetLevel");
        Debug.Log("Animacion de muerte");
    }
}
