using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public LevelScript levelScript;

    public GameObject pauseMenuBG;
    public GameObject pauseMenu;
    public GameObject quitConfirmMenu;
    public GameObject howToPlayMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (levelScript.isPaused != true)
        {
            //do pause things 
            levelScript.isPaused = true;
            pauseMenuBG.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            levelScript.isPaused = false;
            pauseMenuBG.SetActive(false);
            quitConfirmMenu.SetActive(false);
            howToPlayMenu.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        levelScript.isPaused = false;
        pauseMenuBG.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
