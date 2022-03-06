using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject uiElement;


    // Start is called before the first frame update
    void Start()
    {
        
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
            uiElement.SetActive(true);
        }
    }
}
