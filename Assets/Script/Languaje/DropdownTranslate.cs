using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class DropdownTranslate : ButtonBase
{
    public TMP_Dropdown myText = null;
    public List<string> myID = new List<string>();
    public int myValue = 0;

    void OnEnable()
    {
        myText.onValueChanged.AddListener(delegate
        {
            indexValueChange(myText);
        });

        myText.ClearOptions();
        myText.AddOptions(myID);
    }

    public override void ChangeLang()
    {
        for (int i = 0; i < myID.Count; i++)
        {
            myText.options[i].text = LangMannager.instance.GetTransLate(myID[i]);
        }

        myText.captionText.text = LangMannager.instance.GetTransLate(myID[myText.value]);
    }

    public void indexValueChange(TMP_Dropdown tmpDd)
    {
        myValue = tmpDd.value;
        LangMannager.instance.selectedLanguage = (Language)myValue;
        LangMannager.instance.OnUpdate?.Invoke();
    }
}
