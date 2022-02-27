using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceMaster : MonoBehaviour
{
    public int priceFluctuation;


    private int RanNum, RanNum2, RanNum3;
    private int ingredient1TEST, ingredient2TEST, ingredient3TEST;

    List<int> FiveBaseIngredients = new List<int>();




    private void Awake()
    {
        //set all value here:
        priceFluctuation = 5;

    }




    //=======HOW TO USE InitiateFiveIngredients()=======
    // Call this every day morning -> restore List<>
    // Each num represent different base:
    //1: Mandrake
    //2: Wolfsbane
    //3: Deadman'sDust
    //4: Henbane
    //5: RatGrass
    public void InitiateFiveIngredients()
    {
        FiveBaseIngredients.Add(1);
        FiveBaseIngredients.Add(2);
        FiveBaseIngredients.Add(3);
        FiveBaseIngredients.Add(4);
        FiveBaseIngredients.Add(5);
    }




    //=======HOW TO USE Get3RandomeIngredients(out 1, out 2, out 3)=======
    // Call this every day morning -> regenerate 3 random ingredients
    // step 1: Here randomly generate 3 ingredients
    // step 2: Need to check those 3 out numbers. if(out 1 = 1) {Mandrake's price += priceFluctuation} ...
    public void Get3RandomeIngredients(out int ingredient01, out int ingredient02, out int ingredient03)
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
            }
        }
    }
}
