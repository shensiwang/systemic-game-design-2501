using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndDayManager : MonoBehaviour
{
    public IngredientManager ingredientManagerRef;
    public StartDayManager startDayManagerRef;
    public LevelScript levelScriptRef;
    public GameObject EndDayReport;


    public bool dayEnded; // used in LevelScript when all customer left


    [Header("UI Elements")]
    public TextMeshProUGUI dailySales;
    public TextMeshProUGUI reputationTxt;
    public TextMeshProUGUI dayCountTxt;


    public void CallEndDay()
    {
        UpdateDailySales();
        DisplayOtherUI();
        ShowReviewSheet();
    }


    public void UpdateDailySales()
    {
       //Debug.Log("CalculateDailySales: "+ ingredientManagerRef.CalculateDailySales(100));

        //dailySales.text = "Daily Sales:      " + ingredientManagerRef.CalculateDailySales(100).ToString();
    }

    public void DisplayOtherUI()
    {
        reputationTxt.text = "Reputation:       " + RepManager.repMaster.reputationInGrade;
        dayCountTxt.text = "Day:                  " + levelScriptRef.dayCount;

    }

    public void ShowReviewSheet()
    {
        EndDayReport.SetActive(true);
    }

    public void HideReviewSheet()
    {
        EndDayReport.SetActive(false);
        startDayManagerRef.CallDayMorning();
    }

    public void ResetDayEnded()
    {
        dayEnded = false;
    }
}
