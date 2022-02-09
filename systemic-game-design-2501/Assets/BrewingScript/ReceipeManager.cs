using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceipeManager : MonoBehaviour
{
    private Ingredients currentIngredient;
    public Image customCursor;

    public Slots[] craftingSlots;
    public List<Ingredients> ingredientList;
    public string[] receipeList;
    public string[] receipeResults;

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

                foreach(Slots slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    if(dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }

                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentIngredient.GetComponent<Image>().sprite;
                nearestSlot.ingredients = currentIngredient;
                currentIngredient = null;
            }
        }
    }
}
