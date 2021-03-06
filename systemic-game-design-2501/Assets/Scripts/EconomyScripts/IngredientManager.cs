using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [Header ("5 Base Ingredients")]
    public Ingredients baseMandrake;
    public Ingredients baseWolfsbane;
    public Ingredients baseDeadmanDust;
    public Ingredients baseHenbane;
    public Ingredients baseRatGrass;

    public Ingredients secondaryRed;
    public Ingredients secondaryYellow;
    public Ingredients secondaryBlue;

    private int usedMandrakeAmt;
    private int usedWolfsbaneAmt;
    private int usedDeadmanDustAmt;
    private int usedHenbaneAmt;
    private int usedRatGrassAmt;

    private int usedRedAmt;
    private int usedYellowAmt;
    private int usedBlueAmt;

    private float DailySales;

    public float SalesOnEachTime;

    //=========== this manager just do tracking of the ingredient has used a day =================
    public void ResetIngredientsAmt()
    {
        usedMandrakeAmt     = 0;
        usedWolfsbaneAmt    = 0;
        usedDeadmanDustAmt  = 0;
        usedHenbaneAmt      = 0;
        usedRatGrassAmt     = 0;
        usedRedAmt          = 0;
        usedYellowAmt       = 0;
        usedBlueAmt         = 0;
        DailySales          = 0;
    }

    public void ResetIngredientsPrice()
    {
        baseMandrake.marketPrice    = 5;
        baseWolfsbane.marketPrice   = 5;
        baseDeadmanDust.marketPrice = 5;
        baseHenbane.marketPrice     = 5;
        baseRatGrass.marketPrice    = 5;
        secondaryRed.marketPrice    = 5;
        secondaryYellow.marketPrice = 5;
        secondaryBlue.marketPrice   = 5;


        baseMandrake.sellPrice      =   baseMandrake.marketPrice    ;
        baseWolfsbane.sellPrice     =   baseWolfsbane.marketPrice   ;
        baseDeadmanDust.sellPrice   =   baseDeadmanDust.marketPrice ;
        baseHenbane.sellPrice       =   baseHenbane.marketPrice     ;  
        baseRatGrass.sellPrice      =   baseRatGrass.marketPrice    ;
        secondaryRed.sellPrice      =   secondaryRed.marketPrice    ;
        secondaryYellow.sellPrice   =   secondaryYellow.marketPrice ;
        secondaryBlue.sellPrice     =   secondaryBlue.marketPrice   ;
    }

    //============ call UsedIngredient(string ingredientName) to update inventory ingredient num & to track the num of ingredient you used ===============

    public void UsedIngredient(string ingredientName)     {
        switch (ingredientName)
        {
            case "Mandrake":
                if (baseMandrake.GetCurrentIngredientQuantity() > 0)
                {
                    usedMandrakeAmt++;
                    baseMandrake.currentIngredientQuantity--;
                }
                else { Debug.Log("No more Mandrake"); }
                break;

            case "Wolfsbane":
                if (baseWolfsbane.GetCurrentIngredientQuantity() > 0)
                {
                    usedWolfsbaneAmt++;
                    baseWolfsbane.currentIngredientQuantity--;
                }
                else { Debug.Log("No more Wolfsbane"); }
                break;

            case "DeadmanDust":
                if (baseDeadmanDust.GetCurrentIngredientQuantity() > 0)
                {
                    usedDeadmanDustAmt++;
                    baseDeadmanDust.currentIngredientQuantity--;
                }
                else { Debug.Log("No more DeadmanDust"); }
                break;

            case "Henbane":
                if (baseHenbane.GetCurrentIngredientQuantity() > 0)
                {
                    usedHenbaneAmt++;
                    baseHenbane.currentIngredientQuantity--;
                }
                else { Debug.Log("No more Henbane"); }
                break;

            case "RatGrass":
                if (baseRatGrass.GetCurrentIngredientQuantity() > 0)
                {
                    usedRatGrassAmt++;
                    baseRatGrass.currentIngredientQuantity--;
                }
                else { Debug.Log("No more RatGrass"); }
                break;

            case "Red":
                if (secondaryRed.GetCurrentIngredientQuantity() > 0)
                {
                    usedRedAmt++;
                    secondaryRed.currentIngredientQuantity--;
                }
                else { Debug.Log("No more RatGrass"); }
                break;

            case "Yellow":
                if (secondaryYellow.GetCurrentIngredientQuantity() > 0)
                {
                    usedYellowAmt++;
                    secondaryYellow.currentIngredientQuantity--;
                }
                else { Debug.Log("No more RatGrass"); }
                break;

            case "Blue":
                if (secondaryBlue.GetCurrentIngredientQuantity() > 0)
                {
                    usedBlueAmt++;
                    secondaryBlue.currentIngredientQuantity--;
                }
                else { Debug.Log("No more RatGrass"); }
                break;

            default:
                Debug.Log("has no such ingredient name, check Ingredient Manager switch case ");
                break;
        }
    }


    //============ call CalculateDailySales() to update the final sales of the day ===============
    public float CalculateDailySales(float multiplier)
    {
        DailySales = baseMandrake.sellPrice * usedMandrakeAmt + baseWolfsbane.sellPrice * usedWolfsbaneAmt + baseDeadmanDust.sellPrice * usedDeadmanDustAmt + baseHenbane.sellPrice * usedHenbaneAmt + baseRatGrass.sellPrice * usedRatGrassAmt + secondaryRed.sellPrice * usedRedAmt + secondaryYellow.sellPrice * usedYellowAmt + secondaryBlue.sellPrice * usedBlueAmt;

        SalesOnEachTime = DailySales * multiplier;
        CurrencyManager.currencyMaster.IncreaseCurrency(SalesOnEachTime);
        Debug.Log("IncreaseCurrency: " + SalesOnEachTime);
        Debug.Log("Total Currency" + CurrencyManager.currencyMaster.currency);
        return DailySales;


    }




}
