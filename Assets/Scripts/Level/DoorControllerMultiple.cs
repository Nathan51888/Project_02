using UnityEngine;

public class DoorControllerMultiple : MonoBehaviour
{
    [SerializeField] private Switch[] switches;
    private BoxCollider2D _collider2D;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
    }

    private void OpenDoor()
    {
        _sprite.enabled = false;
        _collider2D.enabled = false;
    }

    private void CloseDoor()
    {
        _sprite.enabled = true;
        _collider2D.enabled = true;
    }
}