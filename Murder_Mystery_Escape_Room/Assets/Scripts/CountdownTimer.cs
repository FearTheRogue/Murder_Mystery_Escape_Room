﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText;
    public float time = 1200;

    void Start()
    {
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = "20:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            //string fraction = ((time * 100) % 100).ToString("000");
            timerText.text = minutes + ":" + seconds;

            if(time <= 0)
            {
                GameManager.instance.TimeRanOutLose();
            }
        }
    }
}
