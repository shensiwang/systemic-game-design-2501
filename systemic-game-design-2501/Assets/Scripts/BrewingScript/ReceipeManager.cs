using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceipeManager : MonoBehaviour
{
    public LevelScript levelScript;
    public IngredientManager ingredientManagerRef;

    private Ingredients currentIngredient;
    public Image customCursor;
    public Image ingredientBlocker;

    public Slots baseCraftingSlots;
    public Slots[] subCraftingSlots;
    public Slots completePotionSlot;
    public GameObject potionPrefab; //added for placeholder purposes

    public Potions[] potionList;
    public bool[] partMatch;
    public bool[] partUsed;

    public List<Ingredients> ingredientList;
    public string[] receipes;
    public string[] brewingResults;
    public string receipeResults;
    public string currentReceipeString;

    private void Start()
    {
        partMatch = new bool[3];
        partUsed = new bool[3];
    }

    public void OnMouseDownIngredient(Ingredients ingredients)
    {
        if (currentIngredient == null)
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

                if (ingredientList[0] != null && ingredientList[1] != null && ingredientList[2] != null)
                {
                    CheckForCreatedReceipes();
                }
                currentIngredient = null;
                Debug.Log(currentReceipeString);
            }
        }
    }

    public void CheckForCreatedReceipes()
    {
        currentReceipeString = "";
        foreach(Ingredients ingredients in ingredientList)
        {
            Debug.Log(ingredients);
            if(ingredients != null)
            {
                currentReceipeString += ingredients.ingredientName + " ";
            }
            else
            {
                currentReceipeString += "null";
            }
        }

        string[] inputParts = currentReceipeString.Split(' ');
        for(int i = 0; i < receipes.Length; i++)
        {
            string[] receipeParts = receipes[i].Split(' ');
            ResetPartMatch();
            for (int j = 0; j < receipeParts.Length; j++)
            {
                for (int k = 0; k < receipeParts.Length; k++)
                {
                    if (receipeParts[j] == inputParts[k] && partUsed[k] == false)
                    {
                        Debug.Log(receipeParts[j] + " " + j + "=" + "input part" + k);
                        partMatch[j] = true;
                        partUsed[k] = true;
                        break;
                    }
                }

                if(partMatch[j] == false)
                {
                    //Debug.Log("No matching part for" + receipeResults[i]);
                    break;
                }
            }

            if(partMatch[0] == true && partMatch[1] == true && partMatch[2] == true)
            {
                receipeResults = brewingResults[i];
                Debug.Log(receipeResults);
                return;
            }
        }
        Debug.Log( "No brewable potions");
        return;
    }

    public void ResetPartMatch()
    {
        for (int i = 0; i < partMatch.Length; i++)
        {
            partMatch[i] = false;
            partUsed[i] = false;
        }
    }
    public void ResetPot()
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
        ResetPartMatch();
        currentReceipeString = null;
        //CheckForCreatedReceipes();
        ingredientBlocker.gameObject.SetActive(false);
        Debug.Log("Gone");

        //if (potionPrefab != null) Destroy(potionPrefab); //added for placeholder
    }

    public void ClearTable()
    {
        completePotionSlot.potionType = null;
        completePotionSlot.potionElement = null;
        completePotionSlot.gameObject.SetActive(false);
        ResetPot();

        //if(potionPrefab != null) Destroy(potionPrefab); //added for placeholder
    }

    public void BrewPotion()
    {
        foreach (Potions potion in potionList)
        {
            if(potion.name == receipeResults)
            {
                Debug.Log("Brew");
                completePotionSlot.gameObject.SetActive(true);
                completePotionSlot.GetComponent<Image>().sprite = potion.GetComponent<Image>().sprite;

                potionPrefab = Instantiate(potion.gameObject, completePotionSlot.transform); //added for placeholder


                completePotionSlot.potionType = potion.potionType;
                completePotionSlot.potionElement = potion.potionElement;
                receipeResults = null;

                for (int i = 0; i < ingredientList.Count; i++) // before reset the pot, record the ingredient amount you used to brew potion
                {
                    ingredientManagerRef.UsedIngredient(ingredientList[i].ingredientName);
                    Debug.Log("Brew success! Ingredient amount have recorded ");
                }

                ResetPot();
            }
            else { Debug.Log("Cannot be brewed!");}
        }
    }

    public void SellPotion()
    {
        //What happens after the potion is sold
        levelScript.SellPotion(); //use the function found in levelscript (since it has info on customer.)
        
        


        /*
        completePotionSlot.potionType = null;
        completePotionSlot.potionElement = null;
        completePotionSlot.gameObject.SetActive(false);*/ //shifted to levelscript.


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
