using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Variables
    [Header("Miscellaneous")]
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

    //Menu buttons Variables
    [Header("Menu Buttons")]
    //How to Play Variables
    public GameObject howToPlay;
    public GameObject creditScreen;

    //SFX Variables
    [Header("SFX")]
    public AudioClip menuBGM;
    public AudioClip cutsceneBGM;
    public AudioClip fireBurning;
    public AudioClip glassBottle;
    public AudioClip rumblingSFX;
    public AudioClip swooshSFX;
    public AudioClip bellSFX;
    public AudioClip closeSFX;

    private AudioSource cutsceneSound;
    public AudioSource bgmSound;

    public void Start()
    {
        cutsceneSound = this.GetComponent<AudioSource>();
    }

    //Main Menu Transitions
    public void PlayGame()
    {
        Load.playButtonPresed();
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
    }

    public void QuitGame()
    {
        quitGameComfirmation.SetActive(true);
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
    }

    public void DontQuitGame()
    {
        quitGameComfirmation.SetActive(false);
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
    }

    public void QuitGameConfirmation()
    {
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
        Application.Quit();
    }

    public void OpenCredit()
    {
        creditScreen.SetActive(true);
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
    }

    public void CloseCredit()
    {
        creditScreen.SetActive(false);
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
    }


    //CUTSCENE FUNCTIONS - Pls dont mess with this 
    public void FadeToBlack()
    {
        cutsceneSound.clip = closeSFX;
        cutsceneSound.Play();
        fadeIn.SetActive(true);
        fadeAnim.SetTrigger("StartCutscene");

        Invoke("Cutscene1", 2f);
    }

    public void Cutscene1()
    {
        cutscene1.SetActive(true);
        bgmSound.clip = cutsceneBGM;
        bgmSound.Play();
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
        cutsceneSound.clip = swooshSFX;
        cutsceneSound.Play();
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
        cutsceneSound.clip = swooshSFX;
        cutsceneSound.Play();
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
        Invoke("Rumble", 1f);
    }

    public void Rumble()
    {
        cutsceneSound.clip = rumblingSFX;
        cutsceneSound.Play();
        Invoke("ShopIntro", 3f);
    }

    public void ShopIntro()
    {
        cutsceneStore.SetActive(true);
        cutsceneAnim.SetTrigger("StoreStart");
        bgmSound.clip = fireBurning;
        bgmSound.Play();
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
        Invoke("GlassBottleSound", 4.2f);
    }

    public void GlassBottleSound()
    {
        cutsceneSound.clip = glassBottle;
        cutsceneSound.Play();
        Invoke("GlassBottleSound2", 2f);
    }

    public void GlassBottleSound2()
    {
        cutsceneSound.clip = glassBottle;
        cutsceneSound.Play();
        Invoke("BellSound", 0.7f);
    }

    public void BellSound()
    {
        cutsceneSound.clip = bellSFX;
        cutsceneSound.Play();
        Invoke("FadeToGame", 1.3f);
    }

    public void FadeToGame()
    {
        fadeAnim.SetTrigger("StartGame");
        Invoke("PlayGame", 1f);
    }
}
