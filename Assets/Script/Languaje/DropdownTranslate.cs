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
    private bool firstEntry = false;

    void OnEnable()
    {
        myText.onValueChanged.AddListener(delegate
        {
            indexValueChange(myText);
        });
    }

    public override void ChangeLang()
    {
        for (int i = 0; i < myID.Count; i++)
        {
            if (firstEntry != true)
            {
                myText.ClearOptions();
                myText.AddOptions(myID);
            }

            for (int x = 0; x < myID.Count; x++)
            {
                myText.options[x].text = LangMannager.instance.GetTransLate(myID[x]);
            }
        }

        firstEntry = true;
        myText.captionText.text = LangMannager.instance.GetTransLate(myID[myText.value]);
    }

    public void indexValueChange(TMP_Dropdown i)
    {
        if (LangMannager.instance.selectedLanguage == Language.eng)
            LangMannager.instance.selectedLanguage = Language.spa;
        else
            LangMannager.instance.selectedLanguage = Language.eng;

        LangMannager.instance.OnUpdate?.Invoke();
    }
}
