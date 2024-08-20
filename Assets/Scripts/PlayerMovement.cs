using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Scalable
{
    private float _x;
    
    [Header("Player movement param")]
    public float speed;
    private bool _isFacingRight;

    private const float JumpForce = 7.5f;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundCheckRadius;

    public Transform respawnPoint;
    void Awake()
    {
        
    }
    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        
        if (_x > 0 && !_isFacingRight)
            Flip();
        if (_x < 0 && _isFacingRight)
            Flip();
        
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * JumpForce; 
            AudioManager.Audio.PlaySound("Jump");
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_x * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    protected override void OnBecameInvisible()
    {
        rb.velocity = Vector2.zero;
        
        if (respawnPoint)
            transform.position = respawnPoint.position;
    }
}
