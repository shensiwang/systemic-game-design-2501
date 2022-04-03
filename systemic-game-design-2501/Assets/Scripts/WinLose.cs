using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLose : MonoBehaviour
{

    public GameObject winMenu;
    public GameObject loseMenu;


    public TextMeshProUGUI loseDescription;

    public string loseDescriptionTextAudreyWin;
    public string loseDescriptionTextBetramWin;

    public Faction factionData;

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

        if (factionData.winningFaction == "A")
        {
            loseDescription.text = loseDescriptionTextAudreyWin;
        }
        else
        {
            loseDescription.text = loseDescriptionTextBetramWin;
        }
    }
}
