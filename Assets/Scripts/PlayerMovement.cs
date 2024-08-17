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

    private float _jumpForce = 5f;
    
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundCheckRadius;
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
        
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * _jumpForce; 
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }
}
