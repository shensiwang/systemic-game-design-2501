using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour
{
    public Faction factionRef;

    //List<int> RandomEvent = new List<int>();
    //public void InitializeList()
    //{
    //    RandomEvent.Add(0);
    //    RandomEvent.Add(0);
    //    RandomEvent.Add(0);
    //}
    //
    //InitializeList(); // outcome: List.count = 3
    //
    //for (int i = 0; i < RandomEvent.Count; i++)
    //{
    //    int num = Random.Range(0, 2); // output: 0/1
    //    if (RandomEvent.Count == 3)
    //    {
    //
    //        RandomEvent.RemoveAt(i); // i: index num
    //    }
    //
    //    if (RandomEvent.Count == 2)
    //    { 
    //
    //    }
    //
    //    if (RandomEvent.Count == 1)
    //    { 
    //
    //    }
    //}

    public void GetRandEvent()
    {
        int faction = Random.Range(0, 2);
        if (faction == 0) // A
        {
            int type = Random.Range(0, 2);
            if (type == 0) // Moral
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) { factionRef.DecreaseMorale("A"); Debug.Log("Random Event:          'A' faction 'decrease' 'morale'. "); }
                else { factionRef.IncreaseMorale("A"); Debug.Log("Random Event:          'A' faction 'increase' 'morale'. "); }
            }

            else // Aggression
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) { factionRef.DecreaseAgression("A"); Debug.Log("Random Event:          'A' faction 'decrease' 'aggression'. "); }
                else { factionRef.IncreaseAgression("A"); Debug.Log("Random Event:          'A' faction 'increase' 'aggression'. "); }
            }
        }

        else  // B
        {
            int type = Random.Range(0, 2);
            if (type == 0) // Moral
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) { factionRef.DecreaseMorale("B"); Debug.Log("Random Event:          'B' faction 'decrease' 'moral'. "); }
                else { factionRef.IncreaseMorale("B"); Debug.Log("Random Event:          'B' faction 'increase' 'moral'. "); }
            }

            else // Aggression
            {
                int quantity = Random.Range(0, 2);
                if (quantity == 0) { factionRef.DecreaseAgression("B"); Debug.Log("Random Event: 'B' faction 'decrease' 'aggression'. "); }
                else { factionRef.IncreaseAgression("B"); Debug.Log("Random Event: 'B' faction 'increase' 'aggression'. "); }
            }
        }


    }



}
