using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }

    public void GameInfo()
    {

    }
    public void QuitGame()
    {   
        Application.Quit();
    }
}
