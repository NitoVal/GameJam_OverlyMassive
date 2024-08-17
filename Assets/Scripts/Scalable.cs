using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Scalable : MonoBehaviour
{
    [Header("Scalable params")] 
    public Rigidbody2D rb;
    
    public float minSize;
    public float maxSize;
    private float _currentSizeX;
    private float _currentSizeY;

    private void Start()
    {
        _currentSizeX = transform.localScale.x;
        _currentSizeY = transform.localScale.y;
    }

    public void Enlarge()
    {
        if (_currentSizeX >= maxSize && _currentSizeY >= maxSize)
        {
            transform.localScale = new Vector3(maxSize, maxSize, 0f);
            return;
        }

        rb.mass += 2f;
        _currentSizeX += .1f;
        _currentSizeY += .1f;
        transform.localScale = new Vector3(_currentSizeX, _currentSizeY, 0f);
    }

    public void Shrink()
    {
        if (_currentSizeX <= minSize && _currentSizeY <= minSize)
        {
            transform.localScale = new Vector3(minSize, minSize, 0f);
            return;
        }

        rb.mass -= 2f;
        _currentSizeX -= .1f;
        _currentSizeY -= .1f;
        transform.localScale = new Vector3(_currentSizeX, _currentSizeY, 0f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnlargePad"))
            Enlarge();
        if (other.gameObject.CompareTag("ShrinkPad"))
            Shrink();
    }
}
