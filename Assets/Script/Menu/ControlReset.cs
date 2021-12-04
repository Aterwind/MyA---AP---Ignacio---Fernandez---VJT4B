using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ControlReset : MonoBehaviour
{
    public Image DefeatImage;
    public void Start()
    {
        Time.timeScale = 1;
        EventManager.Subscribe("ResetLevel", FuncDefeat);
    }
    public void FuncDefeat(object[] parameters)
    {
        DefeatImage.transform.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Play()
    {
        EventManager.Clear();
        SceneManager.LoadScene(1);
    }

}
