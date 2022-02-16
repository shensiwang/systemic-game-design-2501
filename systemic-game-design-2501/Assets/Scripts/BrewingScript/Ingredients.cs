using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public string ingredientName;


    //============== Economy ============
    [SerializeField]
    public int currentIngredient;
    public float sellPrice;
    public float marketPrice;


    private void Awake()
    {
        ingredientName = gameObject.name;
    }

    public int GetCurrentIngredient()
    {
        return currentIngredient;
    }

    public float GetSellPrice()
    {
        return sellPrice;
    }
}
