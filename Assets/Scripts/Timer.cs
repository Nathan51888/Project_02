using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _currentTime;
    private Text timerText;
    private bool isTimerActive = true;

    private void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    private void Update()
    {
        if (!isTimerActive)
            return;
        
        CountTimer();
    }
    
    private void CountTimer()
    {
        _currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        timerText.text = time.Minutes + ":" + time.Seconds + ":" + time.Milliseconds;
    }
    
    public void StartTimer()
    {
        isTimerActive = true;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

    public void SetTimer(float time)
    {
        _currentTime = time;
    }
}
