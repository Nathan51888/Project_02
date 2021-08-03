using UnityEngine;

public class PressSwitch : Switch
{
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Draggable")) TurnOff();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Draggable")) TurnOn();
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