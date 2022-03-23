using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Faction : MonoBehaviour
{
    [Header("Faction UI Elements")]
    public Slider factionAMoraleUI;
    public Slider factionBMoraleUI;

    public Slider factionAAgressionUI;
    public Slider factionBAgressionUI;

    public Slider factionALoyaltyUI;
    public Slider factionBLoyaltyUI;

    public TextMeshProUGUI loyaltyABonusInfo;
    public TextMeshProUGUI loyaltyBBonusInfo;

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

    [Header("Faction House Sprites")]
    public List<Image> redFactionSprites;
    public List<Image> blueFactionSprites;

    public Image currentRedFactionSprite;
    public Image currentBlueFactionSprite;

    [Header("Other Factio info")]
    public string winningFaction;

    private bool oneTimeBonusA6 = false;
    private bool oneTimeBonusB6 = false;

    private bool oneTimeBonusA8 = false;
    private bool oneTimeBonusB8 = false;

    private bool oneTimeBonusA3 = false;
    private bool oneTimeBonusB3 = false;

    //public float moneyMultiplier = 1; //multiply this when adding money. can be used for bonuses or decrease.
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
        //update factioh house sprite

        ChangeFactionSprite();

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

        if (factionALoyalty < 0) factionALoyalty = 0;
        if (factionBLoyalty < 0) factionBLoyalty = 0;


        if (factionAMorale <= 0 || factionBMorale <= 0)
        {
            levelScript.Lose();
        }

        //checkloyalty bonuses
        CheckForLoyaltyBonus();
    }


    private void CheckForLoyaltyBonus()
    {
        if (factionALoyalty >= 80)
        {
            //if (oneTimeBonusA8 == false) //apply bonus only once.
            //{
            //CurrencyManager.currencyMaster.IncreaseCurrency(200);
            //oneTimeBonusA8 = true;
            //}

            factionAPercentagePay = 120f;

            loyaltyABonusInfo.color = Color.green;
            loyaltyABonusInfo.text = "Faction A: +20% pay!";
        }
        else if (factionBLoyalty >= 80)
        {
            //if (oneTimeBonusB8 == false)
            //{
            //CurrencyManager.currencyMaster.IncreaseCurrency(200);
            //oneTimeBonusB8 = true;
            //}

            factionBPercentagePay = 120f;

            loyaltyBBonusInfo.color = Color.green;
            loyaltyBBonusInfo.text = "Faction B: +20% pay!";
        }
        if (factionALoyalty >= 60 && factionALoyalty < 80)
        {
            if(oneTimeBonusA6 == false) //apply bonus only once.
            {
                CurrencyManager.currencyMaster.IncreaseCurrency(250);
                oneTimeBonusA6 = true;

                loyaltyABonusInfo.color = Color.green;
                loyaltyABonusInfo.text = "Faction A: One time bonus of +$250!";
            }
        }
        else if(factionBLoyalty >= 60 && factionBLoyalty < 80)
        {
            if(oneTimeBonusB6 == false)
            {
                CurrencyManager.currencyMaster.IncreaseCurrency(250);
                oneTimeBonusB6 = true;

                loyaltyBBonusInfo.color = Color.green;
                loyaltyBBonusInfo.text = "Faction B: One time bonus of +$250!";
            }
        }

        ///loyalty at 40 or lower - 90% of cost

        if (factionALoyalty <= 40 && factionALoyalty > 30)
        {
            factionAPercentagePay = 90f;

            loyaltyABonusInfo.color = Color.red;
            loyaltyABonusInfo.text = "Faction A: -10% pay!";
        }
        if (factionBLoyalty <= 40 && factionBLoyalty > 30)
        {
            factionBPercentagePay = 90f;

            loyaltyBBonusInfo.color = Color.red;
            loyaltyBBonusInfo.text = "Faction B: -10% pay!";
        }


        ///loyalty at 30 or lower - deduct money
        if (factionALoyalty <= 30 && factionALoyalty > 20)
        {
            if(oneTimeBonusA3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                oneTimeBonusA3 = true;

                loyaltyABonusInfo.color = Color.red;
                loyaltyABonusInfo.text = "Faction A: One time penalty of -$250!";
            }
        }
        if (factionBLoyalty <= 30 && factionALoyalty > 20)
        {
            if (oneTimeBonusB3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                oneTimeBonusB3 = true;

                loyaltyBBonusInfo.color = Color.red;
                loyaltyBBonusInfo.text = "Faction B: One time penalty of -$250!";
            }
        }


        ///loyalty at 20 or lower - //change chance of pay, according to loyalty//
        if (factionALoyalty <= 20)
        {
            factionAchanceOfPay = 70f; //change chance of pay

            loyaltyABonusInfo.color = Color.red;
            loyaltyABonusInfo.text = "Faction A: 30% chance of no payment!";
        }
        else
        {
            factionAchanceOfPay = 100f; //change chance of pay
        }


        if(factionBLoyalty <= 20f)
        {
            factionBchanceOfPay = 70f;

            loyaltyBBonusInfo.color = Color.red;
            loyaltyBBonusInfo.text = "Faction B: 30% chance of no payment!";
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

    private void ChangeFactionSprite()
    {
        if((factionAMorale / maxMorale) * 100 <= 20)
        {
            currentRedFactionSprite.sprite = redFactionSprites[0].sprite;
        }
        else if((factionAMorale / maxMorale) * 100 <= 40)
        {
            currentRedFactionSprite.sprite = redFactionSprites[1].sprite;
        }
        else if ((factionAMorale / maxMorale) * 100 <= 60)
        {
            currentRedFactionSprite.sprite = redFactionSprites[2].sprite;
        }
        else if ((factionAMorale / maxMorale) * 100 <= 80)
        {
            currentRedFactionSprite.sprite = redFactionSprites[3].sprite;
        }
        else if ((factionAMorale / maxMorale) * 100 <= 100)
        {
            currentRedFactionSprite.sprite = redFactionSprites[4].sprite;
        }

        if ((factionBMorale / maxMorale) * 100 <= 20)
        {
            currentBlueFactionSprite.sprite = blueFactionSprites[0].sprite;
        }
        else if ((factionBMorale / maxMorale) * 100 <= 40)
        {
            currentBlueFactionSprite.sprite = blueFactionSprites[1].sprite;
        }
        else if ((factionBMorale / maxMorale) * 100 <= 60)
        {
            currentBlueFactionSprite.sprite = blueFactionSprites[2].sprite;
        }
        else if ((factionBMorale / maxMorale) * 100 <= 80)
        {
            currentBlueFactionSprite.sprite = blueFactionSprites[3].sprite;
        }
        else if ((factionBMorale / maxMorale) * 100 <= 100)
        {
            currentBlueFactionSprite.sprite = blueFactionSprites[4].sprite;
        }
    }
}
