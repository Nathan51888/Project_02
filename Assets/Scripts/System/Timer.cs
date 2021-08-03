using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : GenericSingleton<Timer>
{
    public float totalTime;
    private float _currentLevelTime;
    private float _currentTotalTime;
    private bool isTimerActive = true;
    private Text levelTimerText;
    private Text totalTimerText;

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
        var totalTimeSpan = TimeSpan.FromSeconds(_currentTotalTime);
        var levelTimeSpan = TimeSpan.FromSeconds(_currentLevelTime);
        totalTimerText.text = totalTimeSpan.Minutes + ":" + totalTimeSpan.Seconds + ":" + totalTimeSpan.Milliseconds;
        levelTimerText.text = levelTimeSpan.Minutes + ":" + levelTimeSpan.Seconds + ":" + levelTimeSpan.Milliseconds;
    }
}