using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _levelIndex = 1;
    
    public void NextLevel()
    {
        _levelIndex++;
        SceneManager.LoadScene("Level " + _levelIndex);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
