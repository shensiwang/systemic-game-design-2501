using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyMaster : MonoBehaviour
{
    public TextMeshProUGUI currencyTxt;

    int id;
    public int currency;
    

    private void Awake()
    {
        CurrencyManager.SetCurrencyMaster(this);
        //DontDestroyOnLoad(this);
    }

    private void Start()   
    {
        id = 1;
        currency = 0; 
    }

    private void Update()
    {
        currencyTxt.text = "" + currency.ToString();
        if (currency < 0) currency = 0;


        if(Input.GetKey(KeyCode.W))
        {
            IncreaseCurrency(1000);
        }
    }

    public void IncreaseCurrency(float amount)
    {
        currency += (int)amount;
    }

    public void decreaseCurrency(float amount)
    {
        currency -= (int)amount;
    }

}
