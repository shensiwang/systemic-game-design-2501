using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepMaster : MonoBehaviour
{
    public string reputationInGrade;

    int id;
    public int reputationAmount;
    int reputationRating; //rating in int. 0 being the lowest

    public int repReducedPercustomer;


    [Header("Rating Amounts")]
    public int ARatingAmount;
    public int BRatingAmount;
    public int CRatingAmount;
    public int DRatingAmount;

    [Header("Patience change per reputation")]
    //public int patienceChange; 
    //how much patience changes per each reputation
    public int patienceReducedOnARating;
    public int patienceReducedOnBRating;
    public int patienceReducedOnCRating;
    public int patienceReducedOnDRating;

    [SerializeField]
    int customerPatienceChange = 0; //amount to be added to customer patience

    public int customerAmountChangePerRep;

    private void Awake()
    {


        RepManager.SetRepMaster(this);
        DontDestroyOnLoad(this);

        CheckReputation();

        //repReducedPercustomer = 4;
}

    private void Start()
    {
        id = 2;
        
    }

    private void Update()
    {
        CheckReputation();

        //Debug.Log(reputationRating);
    }

    public void IncreaseRep(int amount)
    {
        reputationAmount += amount;
    }

    public void DecreaseRep(int amount)
    {
        reputationAmount -= amount;
    }

    public void CheckReputation() //need some way to check reputation
    {
        if (reputationAmount >= DRatingAmount && reputationAmount < CRatingAmount)
        {
            reputationRating = 0;
            reputationInGrade = "D";
        }

        else if (reputationAmount >= CRatingAmount && reputationAmount < BRatingAmount)
        {
            reputationRating = 1;
            reputationInGrade = "C";
        }

        else if (reputationAmount >= BRatingAmount && reputationAmount < ARatingAmount)
        {
            reputationRating = 2;
            reputationInGrade = "B";
        }

        else if (reputationAmount >= ARatingAmount)
        {
            reputationRating = 3;
            reputationInGrade = "A";
        }
    }

    public int CustomerAmountChangedFromRep()
    {

        switch (reputationRating)
        {
            case 0:
                customerAmountChangePerRep = 1;
                break;

            case 1:
                customerAmountChangePerRep = 2;
                break;

            case 2:
                customerAmountChangePerRep = 3;
                break;

            case 3:
                customerAmountChangePerRep = 4;
                break;


            //change customer amount by __ amount, based off reputatation;
        }

        return customerAmountChangePerRep;

    }

    public int CustomerRepTimeIncreasement()
    {
        switch (reputationRating)
        {
            case 0:
                customerPatienceChange = -patienceReducedOnDRating;
                break;

            case 1:
                customerPatienceChange = -patienceReducedOnCRating;
                break;

            case 2:
                customerPatienceChange = -patienceReducedOnBRating;
                break;

            case 3:
                customerPatienceChange = -patienceReducedOnARating;
                break;


                //change custoer patiece by __ amount, based off reputatation. patience is reduced the higher the rep.
        }

        return customerPatienceChange;
    }

}
