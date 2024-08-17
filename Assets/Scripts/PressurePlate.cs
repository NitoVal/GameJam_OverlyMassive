using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int activateIndex;
    public float minMassRequired;
    public float maxMass;
    public float currentWeight;
    
    public static event Action<int> onActivate;
    public static event Action<int> onDeactivate;
    void Awake()
    {
        
    }

    private void Update()
    {
        if (currentWeight >= minMassRequired && currentWeight <= maxMass)
            onActivate?.Invoke(activateIndex);
        else
            onDeactivate?.Invoke(activateIndex);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.attachedRigidbody)
        {
            currentWeight += other.collider.attachedRigidbody.mass;
            other.collider.gameObject.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.attachedRigidbody)
        {
            currentWeight -= other.collider.attachedRigidbody.mass;
            other.collider.gameObject.transform.SetParent(null);
        }
    }
    private void OnApplicationQuit()
    {
        transform.DetachChildren();
    }
}
