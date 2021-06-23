using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Timer.Instance == null)
                return;
            if (GameManager.Instance == null)
                return;
            
            Timer.Instance.StopTimer();
            GameManager.Instance.LoadScene(GameManager.GameScenes.Level);
        }
    }
}
