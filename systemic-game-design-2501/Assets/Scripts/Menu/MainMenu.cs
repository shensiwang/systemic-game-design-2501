using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quitGameComfirmation;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
