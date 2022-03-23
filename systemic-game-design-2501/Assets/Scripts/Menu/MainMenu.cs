using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quitGameComfirmation;
    public Loadscreen Load;

    public void Update()
    {
        
    }

    public void PlayGame()
    {
        Load.playButtonPresed();
    }

    public void QuitGame()
    {
        quitGameComfirmation.SetActive(true);
    }

    public void DontQuitGame()
    {
        quitGameComfirmation.SetActive(false);
    }

    public void QuitGameConfirmation()
    {
        Application.Quit();
    }
}
