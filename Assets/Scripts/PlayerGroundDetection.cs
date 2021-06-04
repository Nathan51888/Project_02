using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour
{
    public float rayDistance;
    public LayerMask groundLayer;

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, rayDistance, groundLayer);

        if (hit.collider == true)
            return true;
        
        return false;
    }
}
