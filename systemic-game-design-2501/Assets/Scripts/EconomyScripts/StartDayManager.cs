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

    public float priceAnimDuration;

    //=======HOW TO USE CallDayMorning()=======
    // put everthing you need to reset for each day. eg: customer counter, ingredient price ...

    public void CallDayMorning()
    {

        levelScriptRef.numberOfCustomersLeft = levelScriptRef.totalCustomersPerDay;

        //Get Event then spawn customer
        StartCoroutine(DelayedSpawnCustomer());

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
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseMandrake));
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseWolfsbane));
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseDeadmanDust));
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseHenbane));
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseRatGrass));
                break;
        }

        switch (ingredient2)
        {
            case 1:
                ingredientManagerRef.baseMandrake.sellPrice = ingredientManagerRef.baseMandrake.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseMandrake));
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseWolfsbane));
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseDeadmanDust));
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseHenbane));
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseRatGrass));
                break;
        }

        switch (ingredient3)
        {
            case 1:
                ingredientManagerRef.baseMandrake.sellPrice = ingredientManagerRef.baseMandrake.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseMandrake));
                break;

            case 2:
                ingredientManagerRef.baseWolfsbane.sellPrice = ingredientManagerRef.baseWolfsbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseWolfsbane));
                break;

            case 3:
                ingredientManagerRef.baseDeadmanDust.sellPrice = ingredientManagerRef.baseDeadmanDust.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseDeadmanDust));
                break;

            case 4:
                ingredientManagerRef.baseHenbane.sellPrice = ingredientManagerRef.baseHenbane.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseHenbane));
                break;

            case 5:
                ingredientManagerRef.baseRatGrass.sellPrice = ingredientManagerRef.baseRatGrass.marketPrice + priceMasterRef.priceFluctuation;
                //StartCoroutine(RisePrice(priceAnimDuration, ingredientManagerRef.baseRatGrass));
                break;
        }

        Debug.Log("new 5 ingredient price: baseMandrake: " + ingredientManagerRef.baseMandrake.sellPrice + ", baseWolfsbane: " + ingredientManagerRef.baseWolfsbane.sellPrice + ", baseDeadmanDust: " + ingredientManagerRef.baseDeadmanDust.sellPrice + ", baseHenbane: " + ingredientManagerRef.baseHenbane.sellPrice + "，baseRatGrass: " + ingredientManagerRef.baseRatGrass.sellPrice);

    }

    IEnumerator RisePrice(float duration, Ingredients ingredient)
    {
        ingredient.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        ingredient.transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator DelayedSpawnCustomer()
    {
        eventMasterRef.GetEvent();
        yield return new WaitForSeconds(eventMasterRef.eventPopUpTime);
        levelScriptRef.SpawnCustomer();
    }

}
