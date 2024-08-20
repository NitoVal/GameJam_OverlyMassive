using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCoin : MonoBehaviour
{
    public GameObject winScreen;

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        AudioManager.Audio.PlaySound("CoinPickup");
        Time.timeScale = 0f;
        if(winScreen)
            winScreen.SetActive(true);
    }
}
