using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{

    public GameObject winMenu;
    public GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        winMenu.SetActive(true);
    }

    public void Lose()
    {
        loseMenu.SetActive(true);
    }
}
