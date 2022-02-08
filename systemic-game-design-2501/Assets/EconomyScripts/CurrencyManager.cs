using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrencyManager
{
    public static CurrencyMaster currencyMaster;

    public static void SetCurrencyMaster(CurrencyMaster currencyMaster)
    {
        CurrencyManager.currencyMaster = currencyMaster;
    }
}
