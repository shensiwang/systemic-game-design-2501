using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faction : MonoBehaviour
{
    [Header("Faction UI Elements")]
    public Slider factionAMoraleUI;
    public Slider factionBMoraleUI;

    [Header("Level reference")]
    public LevelScript levelScript;

    [Header("Max Amount")]
    public float maxMorale;
    public float maxAgression;
    public int maxLoyalty;

    [Header("Loyalty, Aggression, Morale")]
    public int factionALoyalty;
    public int factionBLoyalty;

    //values of aggression or morale can be float instead.
    public float factionAAgression;
    public float factionBAgression;

    public float factionAMorale;
    public float factionBMorale;

    [Header("Amount to change per stat")]
    public float MoraleChange;
    public float AgressionChange;
    public int LoyaltyChange;

    public string winningFaction;

    // Start is called before the first frame update
    void Start()
    {
        if (factionAMorale > factionBMorale)
        {
            winningFaction = "A";
        }
        else if (factionBMorale > factionAMorale)
        {
            winningFaction = "B";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update bars

        factionAMoraleUI.value = factionAMorale / maxMorale;
        factionBMoraleUI.value = factionBMorale / maxMorale;


        if (factionAMorale > factionBMorale)
        {
            winningFaction = "A";
        }
        else if(factionBMorale > factionAMorale)
        {
            winningFaction = "B";
        }

        ///ensure agression does not go above max or below 0
        if (factionAAgression > maxAgression) factionAAgression = maxAgression;
        if (factionBAgression > maxAgression) factionBAgression = maxAgression;

        if (factionAAgression < 0) factionAAgression = 0;
        if (factionBAgression < 0) factionBAgression = 0;

        ///ensure morale does not go above max
        if (factionAMorale > maxMorale) factionAMorale = maxMorale;
        if (factionBMorale > maxMorale) factionBMorale = maxMorale;


        if (factionAMorale <= 0 || factionBMorale <= 0)
        {
            levelScript.Lose();
        }
    }


    public void DecreaseMorale(string faction)
    {
        if (faction == "A") factionAMorale -= MoraleChange;
        else factionBMorale -= MoraleChange;
    }

    public void IncreaseMorale(string faction)
    {
        if (faction == "A") factionAMorale += MoraleChange;
        else factionBMorale += MoraleChange;
    }

    public void DecreaseAgression(string faction)
    {
        if (faction == "A") factionAAgression -= AgressionChange;
        else factionBAgression -= AgressionChange;
    }

    public void IncreaseAgression(string faction)
    {
        if (faction == "A") factionAAgression += AgressionChange;
        else factionBAgression += AgressionChange;
    }
    public void DecreaseLoyalty(string faction)
    {
        if (faction == "A") factionALoyalty -= LoyaltyChange;
        else factionBLoyalty -= LoyaltyChange;
    }

    public void IncreaseLoyalty(string faction)
    {
        if (faction == "A") factionALoyalty += LoyaltyChange;
        else factionBLoyalty += LoyaltyChange;
    }
}
