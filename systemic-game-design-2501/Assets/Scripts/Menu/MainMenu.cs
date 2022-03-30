using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quitGameComfirmation;
    public GameObject fadeIn;
    public Loadscreen Load;

    //Cutscenes Variables
    [Header("Cutscenes")]
    public Animator fadeAnim;
    public GameObject cutscene1;
    public GameObject dialogueText;
    public GameObject cutsceneStore;
    public Animator cutsceneAnim;
    public Animator dialogueAnim;

    //How to Play Variables
    public GameObject howToPlay;
    public GameObject creditScreen;

    //Main Menu Transitions
    public void PlayGame()
    {
        Load.playButtonPresed();
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
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

    public void OpenCredit()
    {
        creditScreen.SetActive(true);
    }

    public void CloseCredit()
    {
        creditScreen.SetActive(false);
    }


    //CUTSCENE FUNCTIONS - Pls dont mess with this 
    public void FadeToBlack()
    {
        fadeIn.SetActive(true);
        fadeAnim.SetTrigger("StartCutscene");

        Invoke("Cutscene1", 2f);
    }

    public void Cutscene1()
    {
        cutscene1.SetActive(true);
        Invoke("CutsceneBar", 0.6f);
    }

    public void CutsceneBar()
    {
        cutsceneAnim.SetTrigger("CutsceneBar");
        Invoke("BlueFaction", 2f);
    }

    public void BlueFaction()
    {
        cutsceneAnim.SetTrigger("BlueFactionIntro");
        Invoke("Dialogue1", 1f);
    }

    public void Dialogue1()
    {
        dialogueText.SetActive(true);
        Invoke("Dialogue1Fade", 4f);
    }

    public void Dialogue1Fade()
    {
        dialogueAnim.SetTrigger("Dialogue1Fade");
        Invoke("BlueFactionOut", 1f);
    }

    public void BlueFactionOut()
    {
        cutsceneAnim.SetTrigger("BlueFactionOut");
        Invoke("RedFactionIntro", 1f);
    }

    public void RedFactionIntro()
    {
        cutsceneAnim.SetTrigger("RedFactionIntro");
        Invoke("Dialogue2", 1f);
    }

    public void Dialogue2()
    {
        dialogueAnim.SetTrigger("Dialogue2");
        Invoke("Dialogue2Fade", 4f);
    }

    public void Dialogue2Fade()
    {
        dialogueAnim.SetTrigger("Dialogue2Fade");
        cutsceneAnim.SetTrigger("FadeToStore");
        Invoke("ShopIntro", 4f);
    }

    public void ShopIntro()
    {
        cutsceneStore.SetActive(true);
        cutsceneAnim.SetTrigger("StoreStart");
        Invoke("Dialogue3", 2.5f);
    }

    public void Dialogue3()
    {
        dialogueAnim.SetTrigger("Dialogue3");
        Invoke("Dialogue3Fade", 3.5f);
    }

    public void Dialogue3Fade()
    {
        dialogueAnim.SetTrigger("Dialogue3Fade");
        Invoke("Dialogue4", 1.5f);
    }

    public void Dialogue4()
    {
        dialogueAnim.SetTrigger("Dialogue4");
        Invoke("Dialogue4Fade", 3.5f);
    }

    public void Dialogue4Fade()
    {
        dialogueAnim.SetTrigger("Dialogue4Fade");
        Invoke("FadeToGame", 9f);
    }

    public void FadeToGame()
    {
        fadeAnim.SetTrigger("StartGame");
        Invoke("PlayGame", 1f);
    }
}
