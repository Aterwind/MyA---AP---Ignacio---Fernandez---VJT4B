using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTranslate : ButtonBase
{
    public string ID;
    public TextMeshProUGUI myText;
    public override void ChangeLang()
    {
        myText.text = LangMannager.instance.GetTransLate(ID);
    }
}
