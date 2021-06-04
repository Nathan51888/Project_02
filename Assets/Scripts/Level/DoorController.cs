using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private BoxCollider2D _collider2D;
    [SerializeField] private Switch[] switches;
    
    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        foreach (var i in switches)
        {
            if (i.IsActivated)
            {
                OpenDoor();
                return;
            }

            CloseDoor();
        }
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
