using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public Sprite[] pages;
    public int currentPage;
    public Image shownPage;
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
        if (currentPage == 1)
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
        if (currentPage == 12)
        {
            currentPage = 12;
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
                shownPage.GetComponent<Image>().sprite = pages[0];
                break;
            case 2:
                shownPage.GetComponent<Image>().sprite = pages[1];
                break;
            case 3:
                shownPage.GetComponent<Image>().sprite = pages[2];
                break;
            case 4:
                shownPage.GetComponent<Image>().sprite = pages[3];
                break;
            case 5:
                shownPage.GetComponent<Image>().sprite = pages[4];
                break;
            case 6:
                shownPage.GetComponent<Image>().sprite = pages[5];
                break;
            case 7:
                shownPage.GetComponent<Image>().sprite = pages[6];
                break;
            case 8:
                shownPage.GetComponent<Image>().sprite = pages[7];
                break;
            case 9:
                shownPage.GetComponent<Image>().sprite = pages[8];
                break;
            case 10:
                shownPage.GetComponent<Image>().sprite = pages[9];
                break;
            case 11:
                shownPage.GetComponent<Image>().sprite = pages[10];
                break;
            case 12:
                shownPage.GetComponent<Image>().sprite = pages[11];
                break;
        }
    }

    IEnumerator Fade(bool isFade)
    {
        if (isFade)
        {
            for (float i = 1; i >= 0; i -= 3 * Time.unscaledDeltaTime)
            {
                shownPage.color = new Color(1, 1, 1, i);
                yield return null;
            }
            StartCoroutine(Fade(false));
        }
        else
        {
            CheckShownPage();
            for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
            {
                shownPage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    public void Update()
    {
        if (currentPage == 1)
        {
            leftButton.interactable = false;
        }

        else if (currentPage == 12)
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
