using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private float _currentScore;
    [SerializeField] private TextMeshProUGUI _currentScoreText;


    private void Start()
    {
        EventManager.Subscribe("OnScoreUpdate", ScoreChanger);
    }
    //private void Update() Testesa el evento de udpatear el score
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //        EventManager.Trigger("OnScoreUpdate", 100);
    //}

    private void ScoreChanger(params object[] parameters)
    {
        _currentScore += (int)parameters[0];
        _currentScoreText.text = _currentScore.ToString();
    }

}
