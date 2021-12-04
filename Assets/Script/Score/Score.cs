using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Estructura")]
    public PowerUpData scoreData;

    [Header("Textos")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;

    private float _playerHp = 0;
    private float _playerMaxHp = 0;
    private float _points = 0;
    public int nextPowerUp = 0;

    private void Awake()
    {
        EventManager.Subscribe("UpdateUIhp", UpdateHpText);
        EventManager.Subscribe("UpdateUIScore", UpdateScoreText);
    }
    void UpdateHpText(object[] parameters)
    {
        if(parameters[0] != null)
            _playerHp = (float)parameters[0];

        if (parameters[1] != null)
            _playerMaxHp = (float)parameters[1];

        hpText.text = _playerHp + " / " + _playerMaxHp;
    }
    void UpdateScoreText(object[] parameters)
    {
        _points += (float)parameters[0];
        scoreText.text = _points.ToString();

        if (_points >= scoreData.points)
        {
            EventManager.Trigger(scoreData.events);
            scoreData.points += nextPowerUp;
        }
    }
}

[System.Serializable]
public struct PowerUpData
{
    public int points;
    public string events;
}

