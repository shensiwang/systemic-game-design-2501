using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelScript theLevel;
    public Animator thisAnim;
    private void Start()
    {
        thisAnim = gameObject.GetComponent<Animator>();
        Scene thisScene = SceneManager.GetActiveScene();
        Debug.Log(thisScene.buildIndex);
        if(thisScene.buildIndex == 1)
        {
            OpenShop();
        }
        else if( thisScene.buildIndex==0)
        {
            Debug.Log("Main Menu opening");
            OpenMenu();
        }
    }

    public void OpenShop()
    {
        thisAnim.Play("Open");
    }
    public void OpenMenu()
    {
        thisAnim.Play("OpenMainMenu");
    }
    public void playButtonPresed()
    {
        thisAnim.Play("CloseToPlay");
    }
    public void MainMenuButtonPresed()
    {
        thisAnim.Play("CloseToMainMenu");
    }
    public void GoToPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void startTheDay()
    {
        theLevel.startDayManagerRef.CallDayMorning();
    }
 
}
