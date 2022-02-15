using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceipeManager : MonoBehaviour
{
    private Ingredients currentIngredient;
    public Image customCursor;
    public Image ingredientBlocker;

    public Slots baseCraftingSlots;
    public Slots[] subCraftingSlots;
    public Slots completePotionSlot;

    public List<Ingredients> ingredientList;
    public string[] receipes;
    public string[] brewingResults;
    public string receipeResults;
    public string currentReceipeString;

    public void OnMouseDownIngredient(Ingredients ingredients)
    {
        if(currentIngredient == null)
        {
            currentIngredient = ingredients;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentIngredient.GetComponent<Image>().sprite;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentIngredient != null)
            {
                customCursor.gameObject.SetActive(false);
                Slots nearestSlot = null;
                float shortestDistance = float.MaxValue;

                if (currentIngredient.gameObject.CompareTag("SubIngredient"))
                {
                    foreach (Slots slot in subCraftingSlots)
                    {
                        float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                        if (dist < shortestDistance)
                        {
                            shortestDistance = dist;
                            nearestSlot = slot;
                        }
                    }
                }

                else if (currentIngredient.gameObject.CompareTag("BaseIngredient"))
                {
                    float dist = Vector2.Distance(Input.mousePosition, baseCraftingSlots.transform.position);
                    if (dist < shortestDistance)
                    {
                        nearestSlot = baseCraftingSlots;
                        ingredientBlocker.gameObject.SetActive(true);
                    }
                  
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentIngredient.GetComponent<Image>().sprite;
                nearestSlot.ingredients = currentIngredient;
                ingredientList[nearestSlot.index] = currentIngredient;

                CheckForCreatedReceipes();
                currentIngredient = null;
                Debug.Log(currentReceipeString);
            }
        }
        Debug.Log(ingredientList[0].ingredientName);
    }

    public void CheckForCreatedReceipes()
    {
        currentReceipeString = "";
        foreach(Ingredients ingredients in ingredientList)
        {
            Debug.Log(ingredients);
            if(ingredients != null)
            {
                currentReceipeString += ingredients.ingredientName;
            }
            else
            {
                currentReceipeString += "null";
            }
        }

        for(int i = 0; i < receipes.Length; i++)
        {
            if(receipes[i] == currentReceipeString)
            {
                Debug.Log(brewingResults[i]);
            }
        }
    }

    public void ResetPot(Slots slot )
    {
        for(int i = 0; i < ingredientList.Count; i++)
        {
            ingredientList[i] = null;
        }

        baseCraftingSlots.gameObject.SetActive(false);
        for (int i = 0; i < subCraftingSlots.Length; i++)
        {
            subCraftingSlots[i].gameObject.SetActive(false);
        }
        CheckForCreatedReceipes();
        ingredientBlocker.gameObject.SetActive(false);
        Debug.Log("Gone");
    }

    public void BrewPotion()
    {
        completePotionSlot.gameObject.SetActive(true);
        //Change Sprite
        //completePotionSlot.GetComponent<Image>().sprite = receipeResults.getCompotent<Image>().sprite;
    }

    public void OnMouseDown(Ingredients ingredients)
    {
        if(currentIngredient == null)
        {
            currentIngredient = ingredients;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentIngredient.GetComponent<Image>().sprite;
        }
    }
}
