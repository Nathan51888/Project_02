using System;
using UnityEngine;

public class PressSwitch : Switch
{
    private SpriteRenderer _sprite;
    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Draggable"))
        {
            TurnOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Draggable"))
        {
            TurnOff();
        }
    }

    public override void TurnOn()
    {
        IsActivated = true;
        _sprite.color = Color.black;
    }

    public override void TurnOff()
    {
        IsActivated = false;
        _sprite.color = Color.white;
    }
}