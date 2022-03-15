using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject uiElement;
    public AudioClip grimoireActivate;

    private AudioSource activateSound;

    // Start is called before the first frame update
    void Start()
    {
        activateSound = this.GetComponent<AudioSource>();
        activateSound.clip = grimoireActivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if(uiElement.activeSelf == true)
        {
            uiElement.SetActive(false);
        }
        else
        {
            activateSound.Play();
            uiElement.SetActive(true);
        }
    }
}
