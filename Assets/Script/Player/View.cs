using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    public void Damage(float life, float maxLife)
    {
        Debug.Log("Vida: "+ life);
    }

    public void Death()
    {
        Debug.Log("Animacion de muerte");
    }
}
