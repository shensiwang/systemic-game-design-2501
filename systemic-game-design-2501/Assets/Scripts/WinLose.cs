using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLose : MonoBehaviour
{

    public GameObject winMenu;
    public GameObject loseMenu;


    public TextMeshProUGUI loseDescription;

    [TextArea(5,5)]
    public string loseDescriptionTextAudreyWin;
    [TextArea(5, 5)]
    public string loseDescriptionTextBetramWin;

    public Faction factionData;


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
