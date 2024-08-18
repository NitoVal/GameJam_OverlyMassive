using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;
    private bool _isOpen;
    void Awake()
    {
        _isOpen = false;
    }

    private void OnEnable()
    {
        PressurePlate.onActivate += OpenDoor;
        PressurePlate.onDeactivate += CloseDoor;
    }

    private void OnDisable()
    {
        PressurePlate.onActivate -= OpenDoor;
        PressurePlate.onDeactivate -= CloseDoor;
    }

    private void Update()
    {
        if (_isOpen)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    private void OpenDoor(int activationId)
    {
        if (id != activationId)
            return;

        _isOpen = true;
    }

    private void CloseDoor(int activationId)
    {
        if (id != activationId)
            return;

        _isOpen = false;
    }
}
