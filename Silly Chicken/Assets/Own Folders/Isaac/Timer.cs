﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    int seconds = (int)(timer % 60);
    int minutes = (int)(timer / 60) % 60;

    string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

    timeText.text = timerString;

        if (timer <= 30)
        {
            timeText.text = "Time Left: " + timer.ToString("F2");
        }
        else
        {
            timeText.text = "Time Left: " + timerString;
        }

        timer -= Time.deltaTime;
    }
}
