using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public int id;
    public GameObject box;
    public Transform spawnPoint;
    
    private GameObject _currentClone;
    private bool _hasGeneratedBox = false;
    private void OnEnable()
    {
        PressurePlate.onActivate += SpawnBox;
        PressurePlate.onDeactivate += ResetGenerator;
    }

    private void OnDisable()
    {
        PressurePlate.onActivate -= SpawnBox;
        PressurePlate.onDeactivate -= ResetGenerator;
    }

    void SpawnBox(int activationId)
    {
        if (activationId != id && !_hasGeneratedBox)
            return;
        if (_currentClone != null)
        {
            _currentClone.transform.position = spawnPoint.position;
            _currentClone.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        else
        {
            _currentClone = Instantiate(box, spawnPoint.position, spawnPoint.rotation);
            _hasGeneratedBox = true;
        }

    }

    void ResetGenerator(int activationId)
    {
        if (activationId != id && _hasGeneratedBox)
            return;
        _hasGeneratedBox = false;
    }
}
