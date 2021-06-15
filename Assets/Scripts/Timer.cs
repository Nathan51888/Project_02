using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : GenericSingleton<Timer>
{
    private float _currentTotalTime;
    private float _currentLevelTime;
    public float totalTime;
    private Text totalTimerText;
    private Text levelTimerText;
    private bool isTimerActive = true;
    
    private void Update()
    {
        if (!isTimerActive ||
            SceneManager.GetActiveScene().name == "Menu" || 
            SceneManager.GetActiveScene().name == "Loading")
            return;
        
        CountTimer();
    }

    public void StopTimer()
    {
        totalTime = _currentTotalTime;
        _currentLevelTime = 0;
        isTimerActive = false;
    }
    
    public void StartTimer()
    {
        totalTimerText = GameObject.Find("TotalTimerText").GetComponent<Text>();
        levelTimerText = GameObject.Find("LevelTimerText").GetComponent<Text>();
        
        _currentTotalTime = totalTime;
        _currentLevelTime = 0;
        isTimerActive = true;
    }
    
    private void CountTimer()
    {
        _currentTotalTime += Time.deltaTime;
        _currentLevelTime += Time.deltaTime;
        TimeSpan totalTimeSpan = TimeSpan.FromSeconds(_currentTotalTime);
        TimeSpan levelTimeSpan = TimeSpan.FromSeconds(_currentLevelTime);
        totalTimerText.text = totalTimeSpan.Minutes + ":" + totalTimeSpan.Seconds + ":" + totalTimeSpan.Milliseconds;
        levelTimerText.text = levelTimeSpan.Minutes + ":" + levelTimeSpan.Seconds + ":" + levelTimeSpan.Milliseconds;
    }
}
