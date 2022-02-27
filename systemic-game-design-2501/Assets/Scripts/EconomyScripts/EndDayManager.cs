using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndDayManager : MonoBehaviour
{
    public IngredientManager ingredientManagerRef;

    public GameObject EndDayReport;
    public TextMeshProUGUI dailySales;

    public void CallEndDay()
    {
        UpdateDailySales();
        ShowReviewSheet();
    }


    public void UpdateDailySales()
    {
        Debug.Log("CalculateDailySales: "+ ingredientManagerRef.CalculateDailySales());

        dailySales.text = "Daily Sales: " + ingredientManagerRef.CalculateDailySales().ToString();
    }

    public void ShowReviewSheet()
    {
        EndDayReport.SetActive(true);
    }

    public void HideReviewSheet()
    {
        EndDayReport.SetActive(false);
    }

}
