using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public float jumpGravity;
    public float lowJumpGravity;
    public float fallGravity;
    public bool isFacingRight;
    public float hangTime;
    public float jumpBuffer;
    private float _hangTimeCounter;
    private float _jumpBufferCounter;
    private bool CanJump => _jumpBufferCounter > 0 && _hangTimeCounter > 0;

    private Rigidbody2D _rb;
    private PlayerGroundDetection _groundDetection;
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundDetection = GetComponent<PlayerGroundDetection>();
        if (Timer.Instance == null)
            return;
        Timer.Instance.StartTimer();
    }

    private void Update()
    {
        runParticle.Play();

        if (Input.GetButtonDown("Respawn"))
        {
            GameManager.Instance.Respawn();
        }

        if (_groundDetection.IsGrounded())
        {
            runParticle.Play();
            _hangTimeCounter = hangTime;
        }
        else
        {
            _hangTimeCounter -= Time.deltaTime;
            runParticle.Stop();
        }

        if (Input.GetButtonDown("Jump") && _rb.velocity.y <= 0)
        {
            _jumpBufferCounter = jumpBuffer;
        }
        else
        {
            _jumpBufferCounter -= Time.deltaTime;
        }
        
        if (CanJump)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float playerAxisX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(playerAxisX * moveSpeed, _rb.velocity.y);
        Flip(playerAxisX);
        
        if (_rb.velocity.y < 0)
            _rb.gravityScale = fallGravity;
        else if (!Input.GetButton("Jump") && _rb.velocity.y > 0)
            _rb.gravityScale = lowJumpGravity;
        else
            _rb.gravityScale = jumpGravity;
    }

    private void Jump()
    {
        _hangTimeCounter = 0;
        _jumpBufferCounter = 0;
        jumpParticle.Play();
        _rb.velocity = Vector2.up * jumpHeight;
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            
            transform.localScale = theScale;
        }
    }
}
