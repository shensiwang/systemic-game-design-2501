using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour
{
    // 1: rand event: affact Moral & Aggrassion (both)
    // 2: pass event type: for customer dialogue use

    public Faction factionRef;
    public GameObject imageAFireB;
    public GameObject imageBFireA;

    public string EventStr;

    public float eventPopUpTime;

    public void GetRandEvent()
    {
        int faction = Random.Range(0, 2);
        if (faction == 0) // A
        {
            int element = Random.Range(0, 2);
            if (element == 0) // Moral
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) // decrease moral
                { 
                    factionRef.DecreaseMorale("A", 40);
                    factionRef.IncreaseMorale("B", 40);
                    StartCoroutine(BFireAEvent());
                    Debug.Log("Random Event:          'A' faction 'decrease' 'morale',          B setting fire to A"); 
                }
                else // increase moral
                { 
                    factionRef.IncreaseMorale("A", 40);
                    factionRef.DecreaseMorale("B", 40);
                    StartCoroutine(AFireBEvent());
                    Debug.Log("Random Event:          'A' faction 'increase' 'morale',          A setting fire to B"); 
                }
            }

            else // Agression
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) // decrease agression
                { 
                    factionRef.DecreaseAgression("A", 40);
                    factionRef.IncreaseAgression("B", 40);
                    StartCoroutine(BFireAEvent());
                    Debug.Log("Random Event:          'A' faction 'decrease' 'aggression',          B setting fire to A"); 
                }
                else // increase agression
                { 
                    factionRef.IncreaseAgression("A", 40);
                    factionRef.DecreaseAgression("B", 40);
                    StartCoroutine(AFireBEvent());
                    Debug.Log("Random Event:          'A' faction 'increase' 'aggression',          A setting fire to B"); 
                }
            }
        }

        else  // B
        {
            int element = Random.Range(0, 2);
            if (element == 0) // Moral
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) // decrease moral
                { 
                    factionRef.DecreaseMorale("B", 40);
                    factionRef.IncreaseMorale("A", 40);
                    StartCoroutine(AFireBEvent());
                    Debug.Log("Random Event:          'B' faction 'decrease' 'moral',          A setting fire to B"); 
                }
                else  // increase moral
                { 
                    factionRef.IncreaseMorale("B", 40);
                    factionRef.DecreaseMorale("A", 40);
                    StartCoroutine(BFireAEvent());
                    Debug.Log("Random Event:          'B' faction 'increase' 'moral',          B setting fire to A"); 
                }
            }

            else // Aggression
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0)  // decrease agression
                { 
                    factionRef.DecreaseAgression("B", 40);
                    factionRef.IncreaseAgression("A", 40);
                    StartCoroutine(AFireBEvent());
                    Debug.Log("Random Event: 'B' faction 'decrease' 'aggression',          A setting fire to B"); 
                }
                else // increase agression
                { 
                    factionRef.IncreaseAgression("B", 40);
                    factionRef.DecreaseAgression("A", 40);
                    StartCoroutine(BFireAEvent());
                    Debug.Log("Random Event: 'B' faction 'increase' 'aggression',          B setting fire to A"); 
                }
            }
        }


    }


    IEnumerator AFireBEvent()
    {
        imageAFireB.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageAFireB.SetActive(false);
    }

    IEnumerator BFireAEvent()
    {
        imageBFireA.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageBFireA.SetActive(false);
    }
    public void GetEvent()
    {
        int typeOfEvent = Random.Range(0, 2);
        if (typeOfEvent == 0)
        {
            EventStr = "Normal";
        }
        else
        {
            GetRandomEvent();
            EventStr = "Fire";
        }
    }

    public string GetEventString()
    {
        return EventStr;
    }

    public void GetRandomEvent()
    {
        if (factionRef.factionAAgression > factionRef.factionBAgression) // A setting fire on B
        {
            int moraleAmt       = Random.Range(5, 30);
            int aggressionAmt   = Random.Range(5, 30);

            // increase moral
            factionRef.IncreaseMorale("A", moraleAmt);
            factionRef.DecreaseMorale("B", moraleAmt); 
            StartCoroutine(AFireBEvent());


            // decrease agression
            factionRef.DecreaseAgression("A", aggressionAmt);
            factionRef.IncreaseAgression("B", aggressionAmt);
            StartCoroutine(AFireBEvent());
            
            Debug.Log("Random Event:   'A' faction 'increase morale', 'decrease aggression'  -  A setting fire to B");
        }

        else if (factionRef.factionAAgression <= factionRef.factionBAgression) // B setting fire on A
        {
            int moraleAmt = Random.Range(5, 30);
            int aggressionAmt = Random.Range(5, 30);

            // increase moral
            factionRef.IncreaseMorale("B", moraleAmt);
            factionRef.DecreaseMorale("A", moraleAmt);
            StartCoroutine(BFireAEvent());
                
            // decrease agression
            factionRef.DecreaseAgression("B", aggressionAmt);
            factionRef.IncreaseAgression("A", aggressionAmt);
            StartCoroutine(BFireAEvent());

            Debug.Log("Random Event:   'B' faction 'increase morale', 'decrease aggression'  -  B setting fire to A");
        }

        else {}


    }
}
