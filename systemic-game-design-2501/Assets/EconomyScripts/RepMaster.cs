using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepMaster : MonoBehaviour
{
    public Text repTxt;

    int id;
    public int reputationAmount;
    int reputationRating; //rating in int. 0 being the lowest


    [Header("-----------Rating Amounts--------------")]
    public int ARatingAmount;
    public int BRatingAmount;
    public int CRatingAmount;
    public int DRatingAmount;

    [Header("-----------Patience change per reputation--------------")]
    public int patienceChange; //how much patience changes per each reputation

    [SerializeField]
    int customerPatienceChange = 0; //amount to be added to customer patience

    private void Awake()
    {
        RepManager.SetRepMaster(this);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        id = 2;
        reputationAmount = 0;
    }

    public void IncreaseRep(int amount)
    {
        reputationAmount += amount;
    }

    public void DecreaseRep(int amount)
    {
        reputationAmount -= amount;
    }

    private void CheckReputation()
    {
        if (reputationAmount >= DRatingAmount && reputationAmount < CRatingAmount) reputationRating = 0;

        else if (reputationAmount >= CRatingAmount && reputationAmount < BRatingAmount) reputationRating = 1;

        else if (reputationAmount >= BRatingAmount && reputationAmount < ARatingAmount) reputationRating = 2;

        else if (reputationAmount >= ARatingAmount) reputationRating = 3;
    }

    public int CustomerRepTimeIncreasement()
    {

        switch (reputationRating)
        {
            case 0:
                customerPatienceChange += patienceChange;
                break;

            case 1:
                customerPatienceChange += patienceChange;
                break;

            case 2:
                customerPatienceChange += patienceChange;
                break;

            case 3:
                customerPatienceChange += patienceChange;
                break;


            //change custoer patiece by __ amount, based off reputatation;
        }

        return customerPatienceChange;

    }
}
