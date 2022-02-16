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

    private int usedMandrakeAmt;
    private int usedWolfsbaneAmt;
    private int usedDeadmanDustAmt;
    private int usedHenbaneAmt;
    private int usedRatGrassAmt;

    private float DailySales;

    //=========== this manager just do tracking of the ingredient has used a day =================
    public void ResetIngredientsAmt()
    {
        usedMandrakeAmt     = 0;
        usedWolfsbaneAmt    = 0;
        usedDeadmanDustAmt  = 0;
        usedHenbaneAmt      = 0;
        usedRatGrassAmt     = 0;
        DailySales          = 0;
    }

    //============ call UsedIngredient(string ingredientName) to update inventory ingredient num & to track the num of ingredient you used ===============

    public void UsedIngredient(string ingredientName)     {
        switch (ingredientName)
        {
            case "Mandrake":
                if (baseMandrake.GetCurrentIngredient() > 0)
                {
                    usedMandrakeAmt++;
                    baseMandrake.currentIngredient--;
                }
                else { Debug.Log("No more Mandrake"); }
                break;

            case "Wolfsbane":
                if (baseWolfsbane.GetCurrentIngredient() > 0)
                {
                    usedWolfsbaneAmt++;
                    baseWolfsbane.currentIngredient--;
                }
                else { Debug.Log("No more Wolfsbane"); }
                break;

            case "DeadmanDust":
                if (baseDeadmanDust.GetCurrentIngredient() > 0)
                {
                    usedDeadmanDustAmt++;
                    baseDeadmanDust.currentIngredient--;
                }
                else { Debug.Log("No more DeadmanDust"); }
                break;

            case "Henbane":
                if (baseHenbane.GetCurrentIngredient() > 0)
                {
                    usedHenbaneAmt++;
                    baseHenbane.currentIngredient--;
                }
                else { Debug.Log("No more Henbane"); }
                break;

            case "RatGrass":
                if (baseRatGrass.GetCurrentIngredient() > 0)
                {
                    usedRatGrassAmt++;
                    baseRatGrass.currentIngredient--;
                }
                else { Debug.Log("No more RatGrass"); }
                break;
            
            default:
                Debug.Log("has no such ingredient name, check Ingredient Manager switch case ");
                break;
        }
    }


    //============ call CalculateDailySales() to update the final sales of the day ===============
    public float CalculateDailySales()
    {
        float MandrakeTotalSales;
        float WolfsbaneTotalSales;
        float DeadmanDustTotalSales;
        float HenbaneTotalSales;
        float RatGrassTotalSales;


        if (usedMandrakeAmt != 0)
        {
            MandrakeTotalSales = baseMandrake.sellPrice * usedMandrakeAmt;
            DailySales += MandrakeTotalSales;
        }
        else if (usedWolfsbaneAmt != 0)
        {
            WolfsbaneTotalSales = baseWolfsbane.sellPrice * usedWolfsbaneAmt;
            DailySales += WolfsbaneTotalSales;
        }
        else if (usedDeadmanDustAmt != 0)
        {
            DeadmanDustTotalSales = baseDeadmanDust.sellPrice * usedDeadmanDustAmt;
            DailySales += DeadmanDustTotalSales;
        }
        else if (usedHenbaneAmt != 0)
        {
            HenbaneTotalSales = baseHenbane.sellPrice * usedHenbaneAmt;
            DailySales += HenbaneTotalSales;
        }
        else if (usedRatGrassAmt != 0)
        {
            RatGrassTotalSales = baseRatGrass.sellPrice * usedRatGrassAmt;
            DailySales += RatGrassTotalSales;
        }

        return DailySales;
    }




}
