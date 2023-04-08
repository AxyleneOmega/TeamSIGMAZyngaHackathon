using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    bool isPaused = false;
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void Unpause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void QuitToMainMenu()
    {
            SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("menu");
        Application.Quit();
    }

}
