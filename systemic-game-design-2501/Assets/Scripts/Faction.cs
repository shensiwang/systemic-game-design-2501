using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faction : MonoBehaviour
{
    [Header("Faction UI Elements")]
    public Slider factionAMoraleUI;
    public Slider factionBMoraleUI;

    public Slider factionAAgressionUI;
    public Slider factionBAgressionUI;

    public Slider factionALoyaltyUI;
    public Slider factionBLoyaltyUI;

    [Header("Level reference")]
    public LevelScript levelScript;

    [Header("Max Amount")]
    public float maxMorale;
    public float maxAgression;
    public float maxLoyalty;

    [Header("Loyalty, Aggression, Morale")]
    public float factionALoyalty;
    public float factionBLoyalty;

    public float factionAAgression;
    public float factionBAgression;

    public float factionAMorale;
    public float factionBMorale;

    [Header("Amount to change per stat")]
    public float MoraleChange;
    public float AgressionChange;
    public int LoyaltyChange;

    public string winningFaction;

    private bool oneTimeBonusA1 = false;
    private bool oneTimeBonusB1 = false;

    private bool oneTimeBonusA3 = false;
    private bool oneTimeBonusB3 = false;

    public float moneyMultiplier = 1; //multiply this when adding money. can be used for bonuses or decrease.
    public float factionAchanceOfPay = 100f;
    public float factionBchanceOfPay = 100f;

    public float factionAPercentagePay = 100f;
    public float factionBPercentagePay = 100f;

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

        factionAAgressionUI.value = factionAAgression / maxAgression;
        factionBAgressionUI.value = factionBAgression / maxAgression;

        factionALoyaltyUI.value = factionALoyalty / maxLoyalty;
        factionBLoyaltyUI.value = factionBLoyalty / maxLoyalty;


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


    private void CheckForLoyaltyBonus()
    {
        if(factionALoyalty >= 60)
        {
            if(oneTimeBonusA1 == false) //apply bonus only once.
            {
                oneTimeBonusA1 = true;
                //bonus here
                //add money
            }
        }
        else if(factionBLoyalty >= 60)
        {
            if(oneTimeBonusB1 == false)
            {
                oneTimeBonusB1 = true;
                
            }
        }

        ///loyalty at 40 or lower - 90% of cost

        if (factionALoyalty <= 40)
        {
            factionAPercentagePay = 90f;
        }
        if (factionBLoyalty <= 40)
        {
            factionBPercentagePay = 90f;
        }


        ///loyalty at 30 or lower - deduct money
        if (factionALoyalty <= 30)
        {
            if(oneTimeBonusA3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                oneTimeBonusA3 = true;
            }
        }
        if (factionBLoyalty <= 30)
        {
            if (oneTimeBonusB3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                oneTimeBonusB3 = true;
            }
        }


        ///loyalty at 20 or lower - //change chance of pay, according to loyalty//
        if (factionALoyalty <= 20)
        {
            factionAchanceOfPay = 70f; //change chance of pay
        }
        else
        {
            factionAchanceOfPay = 100f; //change chance of pay
        }


        if(factionBLoyalty <= 20f)
        {
            factionBchanceOfPay = 70f;
        }
        else
        {
            factionBchanceOfPay = 100f;
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

    public void DecreaseMorale(string faction, float moraleChange)
    {
        if (faction == "A") factionAMorale -= moraleChange;
        else factionBMorale -= moraleChange;
    }

    public void IncreaseMorale(string faction, float moraleChange)
    {
        if (faction == "A") factionAMorale += moraleChange;
        else factionBMorale += moraleChange;
    }

    public void DecreaseAgression(string faction, float agressionChange)
    {
        if (faction == "A") factionAAgression -= agressionChange;
        else factionBAgression -= agressionChange;
    }

    public void IncreaseAgression(string faction, float agressionChange)
    {
        if (faction == "A") factionAAgression += agressionChange;
        else factionBAgression += agressionChange;
    }
}
