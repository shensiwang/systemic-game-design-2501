using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public string ingredientName;


    //============== Economy ============
    [SerializeField]
    public int currentIngredientQuantity;
    public float sellPrice;
    public float marketPrice;


    private void Awake()
    {
        ingredientName = gameObject.name;
    }

    public int GetCurrentIngredientQuantity()
    {
        return currentIngredientQuantity;
    }

    public float GetSellPrice()
    {
        return sellPrice;
    }
}
