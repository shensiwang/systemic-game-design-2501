using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDayManager : MonoBehaviour
{
    public PriceMaster priceMasterRef;
    private int ingredient1TEST, ingredient2TEST, ingredient3TEST;


    public void ProduceRamdomSellingPrice()
    {
        priceMasterRef.Get3RandomeIngredients(out ingredient1TEST, out ingredient2TEST, out ingredient3TEST);

        
    }
}
