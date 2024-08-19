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

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (_isPaused)
                Resume();
            else
                Pause();
        }
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
        _isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
