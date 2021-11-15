using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    void Start()
    {
        LangMannager.instance.OnUpdate += ChangeLang;
    }
    public abstract void ChangeLang();

}
