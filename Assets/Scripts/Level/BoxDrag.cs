using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrag : MonoBehaviour
{
    private bool isHeldDown = false;
    private float startPosX;
    private float startPosY;
    private bool isTouchingPlayer = false;
    private bool isTouching;
    public float followSpeed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void Update()
    {
        if (isHeldDown && !isTouching)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (isHeldDown && !isTouchingPlayer)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            rb.velocity = (mousePos - transform.position) * followSpeed;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            isHeldDown = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnMouseDown()
    {
        if (!isTouchingPlayer)
        {
            isHeldDown = true;
        }
    }
    private void OnMouseUp()
    {
        isHeldDown = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        isTouching = true;
        if (other.collider.CompareTag("Player") && 
            other.collider.transform.position.y >= transform.position.y)
        {
            isTouchingPlayer = true;
            sprite.color = Color.red;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isTouching = false;
        if (other.collider.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            sprite.color = Color.green;
        }
    }
}
