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

    public List<Ingredients> ingredientList;
    public string[] receipes;
    public Ingredients[] brewingResults;
    public string receipeResults;

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
            if(currentIngredient != null)
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

                currentIngredient = null;
                Debug.Log(ingredientList[nearestSlot.index]);
                CheckForCreatedReceipes();
            }
        }
    }

    public void CheckForCreatedReceipes()
    {
        string currentReceipeString = "";
        foreach(Ingredients ingredients in ingredientList)
        {
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
                Debug.Log(currentReceipeString);
            }
        }
    }

    public void ResetPot(Slots slot )
    {
        baseCraftingSlots.ingredients = null;
        ingredientList[slot.index] = null;
        CheckForCreatedReceipes();
        ingredientBlocker.gameObject.SetActive(false);
        Debug.Log("Gone");
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
