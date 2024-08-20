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
    }

    private void OnDisable()
    {
        PressurePlate.onActivate -= OpenDoor;
    }

    private void Update()
    {
        gameObject.SetActive(!_isOpen);
    }

    private void OpenDoor(int activationId)
    {
        if (id != activationId)
            return;

        _isOpen = true;
        AudioManager.Audio.PlaySound("OpenDoor");
    }
}
