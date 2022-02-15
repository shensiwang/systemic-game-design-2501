using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyMaster : MonoBehaviour
{
    public Text currencyTxt;

    int id;
    int currency;
    

    private void Awake()
    {
        CurrencyManager.SetCurrencyMaster(this);
        DontDestroyOnLoad(this);
    }

    private void Start()   
    {
        id = 1;
        currency = 0; 
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public void decreaseCurrency(int amount)
    {
        currency -= amount;
    }

}
