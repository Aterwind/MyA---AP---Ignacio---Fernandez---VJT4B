using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public enum Language
{
    eng,
    spa
}

public class LangMannager : MonoBehaviour
{
    public static LangMannager instance;

    Dictionary<Language, Dictionary<string, string>> _languageManager;
    public Action OnUpdate;

    public Language selectedLanguage;
    public string externalURL = "https://drive.google.com/uc?export=download&id=1GRYFU2JAQRVNp6WaA_9vUIPoSDXWW4E4";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(DownloadCSV(externalURL));
        DontDestroyOnLoad(this);
    }

    public string GetTransLate(string id)
    {
        if (!_languageManager[selectedLanguage].ContainsKey(id))
            return "No_Text";
        else
            return _languageManager[selectedLanguage][id];
    }

    IEnumerator DownloadCSV(string url)
    {
        var link = new UnityWebRequest(url);
        link.downloadHandler = new DownloadHandlerBuffer();

        yield return link.SendWebRequest();
        _languageManager = LanguageSelected.LoadCodex(link.downloadHandler.text);
        OnUpdate?.Invoke();

    }
}
