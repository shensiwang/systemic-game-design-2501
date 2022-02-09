using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceMaster : MonoBehaviour
{
    [SerializeField]
    int priceFluctuation;

    List<int> FiveBaseIngredients = new List<int>();

    int RanNum, RanNum2, RanNum3;
    int ingredient1TEST, ingredient2TEST, ingredient3TEST;

    bool hadLooped = true;

    private void Awake()
    {
        InitiateFiveIngredients();
    }
    private void Start()
    {
        Get3RandomeIngredients(ingredient1TEST, ingredient2TEST, ingredient3TEST);
    }
    private void Update()
    {
        //if (hadLooped)
        //{
        //    Get3RandomeIngredients(ingredient1TEST, ingredient2TEST, ingredient3TEST);
        //}
    }

    public void InitiateFiveIngredients()
    {
        FiveBaseIngredients.Add(1);
        FiveBaseIngredients.Add(2);
        FiveBaseIngredients.Add(3);
        FiveBaseIngredients.Add(4);
        FiveBaseIngredients.Add(5);
    }
    public void Get3RandomeIngredients(int ingredient01, int ingredient02, int ingredient03)
    {

        ingredient01 = 0;
        ingredient02 = 0;
        ingredient03 = 0;

        for (int i = 0; i < 3; i++)
        {
            RanNum = Random.Range(0, FiveBaseIngredients.Count);

            if (i == 0)
            {
                ingredient01 = FiveBaseIngredients[RanNum];
                FiveBaseIngredients.RemoveAt(RanNum);
                
            }
            else if(i == 1)
            {
                ingredient02 = FiveBaseIngredients[RanNum];
                FiveBaseIngredients.RemoveAt(RanNum);
                
            }
            else
            {
                ingredient03 = FiveBaseIngredients[RanNum];
                FiveBaseIngredients.RemoveAt(RanNum);
                hadLooped = false;
                Debug.Log("3 random number generated: " + ingredient01 + "," + ingredient02 + ", " + ingredient03);
            }
        }
    }
}
