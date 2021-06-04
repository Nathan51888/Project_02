using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private TextMeshPro ui;

    private void Start()
    {
        ui = GetComponentInChildren<TextMeshPro>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        ui.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ui.enabled = false;
    }
}
