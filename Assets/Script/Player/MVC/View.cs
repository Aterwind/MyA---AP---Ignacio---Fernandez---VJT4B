using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    public View(Model model, ListWeapon unitWeapon)
    {
        model.OnGetDmg += Damage;
        model.OnDeath += Death;
        model.OnGetHp += Receive;
        model.OnGetmaxHp += ChangeMaxHP;
    }

    public void Damage(float life, float maxLife)
    {
        Debug.Log("Vida: "+ life);
    }

    public void Receive(float life)
    {
        Debug.Log("Vida: " + life);
    } 

    public void ChangeMaxHP(float maxHp)
    {
        Debug.Log("Vida maxima: " + maxHp);
    }

    public void Death()
    {
        Debug.Log("Animacion de muerte");
    }
}
