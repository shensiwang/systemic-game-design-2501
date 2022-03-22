using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrimoireScript : MonoBehaviour
{
    public Sprite[] pages;
    public int currentPage;
    public Image leftPage;
    public Image rightPage;
    public Button leftButton;
    public Button rightButton;

    public AudioClip flipGrimoire;
    public AudioClip grimoireClose;

    private AudioSource grimoireSound;

    // Start is called before the first frame update
    void Start()
    {
        grimoireSound = this.GetComponent<AudioSource>();
        currentPage = 1;
        StartCoroutine(Fade(true));
    }

    public void Close()
    {
        grimoireSound.clip = grimoireClose;
        grimoireSound.Play();
        Invoke("DeactivateObj", 0.5f);
    }

    public void DeactivateObj()
    {
        this.gameObject.SetActive(false);
    }

    public void FlipLeft()
    {
        grimoireSound.clip = flipGrimoire;
        grimoireSound.Play();
        if(currentPage == 1)
        {
            currentPage = 1;
            StartCoroutine(Fade(true));
        }
        else 
        {    
            currentPage -= 1;
            StartCoroutine(Fade(true));
        }
    }

    public void FlipRight()
    {
        grimoireSound.clip = flipGrimoire;
        grimoireSound.Play();
        if (currentPage == 8)
        {
            currentPage = 8;
            StartCoroutine(Fade(true));
        }
        else
        {
            currentPage += 1;
            StartCoroutine(Fade(true));
        }
    }

    public void CheckShownPage()
    {
        switch (currentPage)
        {
            case 1:
                leftPage.GetComponent<Image>().sprite = pages[0];
                rightPage.GetComponent<Image>().sprite = pages[1];
                break;
            case 2:
                leftPage.GetComponent<Image>().sprite = pages[2];
                rightPage.GetComponent<Image>().sprite = pages[3];
                break;
            case 3:
                leftPage.GetComponent<Image>().sprite = pages[4];
                rightPage.GetComponent<Image>().sprite = pages[5];
                break;
            case 4:
                leftPage.GetComponent<Image>().sprite = pages[6];
                rightPage.GetComponent<Image>().sprite = pages[7];
                break;
            case 5:
                leftPage.GetComponent<Image>().sprite = pages[8];
                rightPage.GetComponent<Image>().sprite = pages[9];
                break;
            case 6:
                leftPage.GetComponent<Image>().sprite = pages[10];
                rightPage.GetComponent<Image>().sprite = pages[11];
                break;
            case 7:
                leftPage.GetComponent<Image>().sprite = pages[12];
                rightPage.GetComponent<Image>().sprite = pages[13];
                break;
            case 8:
                leftPage.GetComponent<Image>().sprite = pages[14];
                rightPage.GetComponent<Image>().sprite = pages[15];
                break;
        }
    }

    IEnumerator Fade(bool isFade)
    {
        if(isFade)
        {
            for(float i = 1; i >=0; i -= 3*Time.unscaledDeltaTime)
            {
                leftPage.color = new Color(1, 1, 1, i);
                rightPage.color = new Color(1, 1, 1, i);
                yield return null;
            }
            StartCoroutine(Fade(false));
        }
        else
        {
            CheckShownPage();
            for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
            {
                leftPage.color = new Color(1, 1, 1, i);
                rightPage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    public void Update()
    {
        if(currentPage == 1)
        {
            leftButton.interactable = false;
        }

        else if(currentPage == 8)
        {
            rightButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

    }
}
