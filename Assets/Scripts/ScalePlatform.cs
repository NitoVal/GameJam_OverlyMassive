using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlatform : MonoBehaviour
{
    public float currrentWeight;
    public float risingWeight;
    public float descendingWeight;
    public Rigidbody2D rb;
    void Awake()
    {
        
    }
    
    void Update()
    {
        if (currrentWeight < risingWeight && currrentWeight > 0)
        {
            rb.velocity = Vector2.up; 
        }
        else if (currrentWeight >= descendingWeight)
        {
            rb.velocity = Vector2.down; 
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.attachedRigidbody)
        {
            currrentWeight += other.collider.attachedRigidbody.mass;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.attachedRigidbody)
        {
            currrentWeight -= other.collider.attachedRigidbody.mass;
        }
    }
}
