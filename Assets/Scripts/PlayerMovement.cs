using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _x;
    
    public Rigidbody2D rb;
    public float speed;
    
    
    void Awake()
    {
        
    }
    
    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_x * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
