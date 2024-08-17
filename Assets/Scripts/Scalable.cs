using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{
    [Header("Scalable params")]
    public float MinSize;
    public float MaxSize;
    private float currentSizeX;
    private float currentSizeY;

    public void Enlarge()
    {
        //if entity has reached the max size limit set it to max
        //Enlarge entity
        if (currentSizeX >= MaxSize && currentSizeY >= MaxSize)
        {
            transform.localScale = new Vector3(MaxSize, MaxSize, 0f);
            return;
        }
        currentSizeX += .1f;
        currentSizeY += .1f;
        transform.localScale = new Vector3(currentSizeX, currentSizeY, 0f);
    }

    public void Shrink()
    {
        //if entity has reached the min size limit set it to min
        //Shrink entity
        if (currentSizeX <= MinSize && currentSizeY <= MinSize)
        {
            transform.localScale = new Vector3(MinSize, MinSize, 0f);
            return;
        }
        currentSizeX -= .1f;
        currentSizeY -= .1f;
        transform.localScale = new Vector3(currentSizeX, currentSizeY, 0f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnlargePad"))
        {
            Enlarge();
        }
        if (other.gameObject.CompareTag("ShrinkPad"))
        {
            Shrink();
        }
    }
}
