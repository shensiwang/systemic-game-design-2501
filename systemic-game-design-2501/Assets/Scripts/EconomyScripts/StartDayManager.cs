using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDayManager : MonoBehaviour
{
    public PriceMaster priceMasterRef;
    public IngredientManager ingredientManagerRef;
    public LevelScript levelScriptRef;
    public EndDayManager endDayManagerRef;
    public EventMaster eventMasterRef;


    private int ingredient1, ingredient2, ingredient3;






    //=======HOW TO USE CallDayMorning()=======
    // put everthing you need to reset for each day. eg: customer counter, ingredient price ...

    public void CallDayMorning()
    {

        levelScriptRef.numberOfCustomersLeft = levelScriptRef.totalCustomersPerDay;
        levelScriptRef.SpawnCustomer();
        eventMasterRef.GetEvent();

        //set dayEnd variables
        endDayManagerRef.ResetDayEnded();

        //set all ingredients economy
        ingredientManagerRef.ResetIngredientsAmt();
        ingredientManagerRef.ResetIngredientsPrice();
        ProduceRamdomSellingPrice();
        BaseIngredientPriceFluctuation();
    }


    public void ProduceRamdomSellingPrice()
    {
        priceMasterRef.InitiateFiveIngredients();
        priceMasterRef.Get3RandomeIngredients(out ingredient1, out ingredient2, out ingredient3);
        Debug.Log("3 random number generated: " + ingredient1 + "," + ingredient2 + ", " + ingredient3);
    }

    public void BaseIngredientPriceFluctuation()
    {
        switch (ingredient1)
        {
            case 1:
                ingredientManagerRef.baseMandrake.sellPrice = ingredientManagerRef.baseMandrake.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                break;
        }

        switch (ingredient2)
        {
            case 1:
                ingredientManagerRef.baseMandrake.sellPrice = ingredientManagerRef.baseMandrake.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                break;
        }

        switch (ingredient3)
        {
            case 1:
                ingredientManagerRef.baseMandrake.sellPrice = ingredientManagerRef.baseMandrake.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                break;
        }

        Debug.Log("new 5 ingredient price: baseMandrake: " + ingredientManagerRef.baseMandrake.sellPrice + ", baseWolfsbane: " + ingredientManagerRef.baseWolfsbane.sellPrice + ", baseDeadmanDust: " + ingredientManagerRef.baseDeadmanDust.sellPrice + ", baseHenbane: " + ingredientManagerRef.baseHenbane.sellPrice + "，baseRatGrass: " + ingredientManagerRef.baseRatGrass.sellPrice);

    }


    
}
