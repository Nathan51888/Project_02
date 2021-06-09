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
            GameManager.Instance.LoadScene(GameManager.GameScenes.Level);
            GameManager.Instance.currentTime = FindObjectOfType<Timer>().GetTime();
        }
    }
}
