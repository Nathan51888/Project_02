using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private TextMeshPro ui;

    private void Start()
    {
        ui = GetComponentInChildren<TextMeshPro>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ui.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        ui.enabled = true;
    }
}