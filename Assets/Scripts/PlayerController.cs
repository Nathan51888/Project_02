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

    private Rigidbody2D _rb;
    private PlayerGroundDetection _groundDetection;
    public ParticleSystem runParticle;
    public ParticleSystem jumpParticle;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundDetection = GetComponent<PlayerGroundDetection>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Respawn"))
        {
            GameManager.Instance.Respawn();
        }
        runParticle.Play();

        if (!_groundDetection.IsGrounded())
        {
            runParticle.Stop();
            return;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jumpParticle.Play();
            _rb.velocity = Vector2.up * jumpHeight;
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
