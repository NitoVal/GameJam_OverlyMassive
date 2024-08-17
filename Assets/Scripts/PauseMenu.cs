using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;

    public GameObject pauseCanvas;

    private void Awake()
    {
        _isPaused = false;
        pauseCanvas.SetActive(_isPaused);
    }

    public void Pause()
    {
        _isPaused = true;
        pauseCanvas.SetActive(_isPaused);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _isPaused = false;
        pauseCanvas.SetActive(_isPaused);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
