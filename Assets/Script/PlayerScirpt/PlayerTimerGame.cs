using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerTimerGame : MonoBehaviour
{

    //Fonction
    private float TimeDuration = 0f * 60f;
    private float timerGameOver;
    private float timerWin;
    private float totalWaves;
    Player_Stat Player;
    GameManager GameManager;

    [Header("GameOverText"), Tooltip("Cette Variable permet de gére le text de gameOver")]
    [SerializeField]
    private TextMeshProUGUI GameOverText;
    [Space(10)]
    [Header("WinText"), Tooltip("Cette Variable permet de gére le text de Win")]
    [SerializeField]
    private TextMeshProUGUI WinText;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {

        if (timerWin >= 0)
        {
            if (!GameManager.gameIsOver)
            {
                timerWin += Time.deltaTime;
                UpadateTimer(timerWin);
            }
            else
            {
                return;
            }

        }

        if (timerGameOver >= 0)
        {
            if (Player_Stat.lives >= 0)
            {
                timerGameOver += Time.deltaTime;
                UpadateTimerDisplay(timerGameOver);
            }
            else
            {
                return;
            }


        }
    }


    private void ResetTimer()
    {
        timerWin = TimeDuration;
        timerGameOver = TimeDuration;
    }

    private void UpadateTimerDisplay(float time)
    {
        TimeSpan _time = TimeSpan.FromSeconds(time);

        string test = $"{_time.Minutes}:{_time.Seconds}:{_time.Milliseconds}";
        GameOverText.text = test;
    }

    private void UpadateTimer(float time)
    {
        TimeSpan _time = TimeSpan.FromSeconds(time);

        string test = $"{_time.Minutes}:{_time.Seconds}:{_time.Milliseconds}";
        WinText.text = test;
    }

}
