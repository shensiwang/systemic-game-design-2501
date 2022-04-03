using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Faction : MonoBehaviour
{
    bool warningAUp = false;
    bool warningBUp = false;


    [Header("Faction Warning UI")]
    public GameObject factionAMoraleWarning;
    public GameObject factionBMoraleWarning;
    public GameObject audreyStealsMoney;
    public GameObject betramStealsMoney;
    public GameObject audreyGiftsMoney;
    public GameObject betramGiftsMoney;

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

    //private bool oneTimeBonusA8 = false;
   // private bool oneTimeBonusB8 = false;

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


        if (factionAMorale <= 0 || factionBMorale <= 0) //lose condition
        {
            levelScript.Lose(); 
        }

        //checkloyalty bonuses
        CheckForLoyaltyBonus();

        //warnings
        //faction a morale warning

        

        if(factionAMorale <= 15 && warningAUp == false)
        {
            factionAMoraleWarning.SetActive(true);
            warningAUp = true;
            if (factionAMoraleWarning.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("end")) //set object active to false via animator tag
            {
                factionAMoraleWarning.SetActive(false);
            }
        }
        else if(factionAMorale > 15)
        {
            factionAMoraleWarning.SetActive(false);
            warningAUp = false;
        }
        //faction b morale warning
        if (factionBMorale <= 15 && warningBUp == false)
        {
            factionBMoraleWarning.SetActive(true);
            warningBUp = true;
            if (factionBMoraleWarning.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("end")) //set object active to false via animator tag
            {
                factionBMoraleWarning.SetActive(false);
            }
        }
        else if (factionBMorale > 15)
        {
            factionBMoraleWarning.SetActive(false);
            warningBUp = false;
        }
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

            loyaltyABonusInfo.color = new Color(0, 0.59f, 0.08f);
            loyaltyABonusInfo.text = "+20% pay!";
        }
        if (factionBLoyalty >= 80)
        {
            //if (oneTimeBonusB8 == false)
            //{
            //CurrencyManager.currencyMaster.IncreaseCurrency(200);
            //oneTimeBonusB8 = true;
            //}

            factionBPercentagePay = 120f;

            loyaltyBBonusInfo.color = new Color(0, 0.59f, 0.08f);
            loyaltyBBonusInfo.text = "+20% pay!";
        }
        if (factionALoyalty >= 60 && factionALoyalty < 80)
        {
            if(oneTimeBonusA6 == false) //apply bonus only once.
            {
                CurrencyManager.currencyMaster.IncreaseCurrency(250);
                oneTimeBonusA6 = true;

                audreyGiftsMoney.SetActive(true);

                loyaltyABonusInfo.color = new Color(0, 0.59f, 0.08f);
                loyaltyABonusInfo.text = "One time bonus of +$250!";
            }
            else
            {
                loyaltyABonusInfo.color = Color.black;
                loyaltyABonusInfo.text = "Bonus previously obtained";
            }
        }
        if(factionBLoyalty >= 60 && factionBLoyalty < 80)
        {
            if(oneTimeBonusB6 == false)
            {
                CurrencyManager.currencyMaster.IncreaseCurrency(250);
                oneTimeBonusB6 = true;

                betramGiftsMoney.SetActive(true);

                loyaltyBBonusInfo.color = new Color(0, 0.59f, 0.08f);
                loyaltyBBonusInfo.text = "One time bonus of +$250!";
            }
            else
            {
                loyaltyBBonusInfo.color = Color.black;
                loyaltyBBonusInfo.text = "Bonus previously obtained";
            }
        }

        ///loyalty at 40 or lower - 90% of cost

        if (factionALoyalty <= 40 && factionALoyalty > 30)
        {
            factionAPercentagePay = 90f;

            loyaltyABonusInfo.color = Color.red;
            loyaltyABonusInfo.text = "-10% pay!";
        }
        if (factionBLoyalty <= 40 && factionBLoyalty > 30)
        {
            factionBPercentagePay = 90f;

            loyaltyBBonusInfo.color = Color.red;
            loyaltyBBonusInfo.text = "-10% pay!";
        }


        ///loyalty at 30 or lower - deduct money
        if (factionALoyalty <= 30 && factionALoyalty > 20)
        {
            if(oneTimeBonusA3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                audreyStealsMoney.SetActive(true);
                oneTimeBonusA3 = true;

                loyaltyABonusInfo.color = Color.red;
                loyaltyABonusInfo.text = "One time penalty of -$250!";
            }
            else
            {
                loyaltyABonusInfo.color = Color.black;
                loyaltyABonusInfo.text = "Penalty previously applied";
            }
        }
        if (factionBLoyalty <= 30 && factionBLoyalty > 20)
        {
            if (oneTimeBonusB3 == false)
            {
                //deduct money
                CurrencyManager.currencyMaster.decreaseCurrency(250);
                betramStealsMoney.SetActive(true);
                oneTimeBonusB3 = true;

                loyaltyBBonusInfo.color = Color.red;
                loyaltyBBonusInfo.text = "One time penalty of -$250!";
            }
            else
            {
                loyaltyBBonusInfo.color = Color.black;
                loyaltyBBonusInfo.text = "Penalty previously applied";
            }
        }


        ///loyalty at 20 or lower - //change chance of pay, according to loyalty//
        if (factionALoyalty <= 20)
        {
            factionAchanceOfPay = 70f; //change chance of pay

            loyaltyABonusInfo.color = Color.red;
            loyaltyABonusInfo.text = "30% chance of no payment!";
        }
        else
        {
            factionAchanceOfPay = 100f; //change chance of pay
        }


        if(factionBLoyalty <= 20f)
        {
            factionBchanceOfPay = 70f;

            loyaltyBBonusInfo.color = Color.red;
            loyaltyBBonusInfo.text = "30% chance of no payment!";
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
