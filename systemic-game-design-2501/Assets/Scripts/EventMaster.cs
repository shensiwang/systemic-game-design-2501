using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour
{
    // 1: rand event: affact Moral & Aggrassion (both)
    // 2: pass event type: for customer dialogue use

    public Faction factionRef;
    
    [Header("Events")]
    public GameObject imageAFireB;
    public GameObject imageBFireA;
    public GameObject imageNormal;
    public GameObject imageHoliday;
    public GameObject imageAPoisonB;
    public GameObject imageBPoisonA;
    public GameObject imageFavourA;
    public GameObject imageFavourB;
    public GameObject imageSecretA;
    public GameObject imageSecretB;

    public string EventStr;

    public float eventPopUpTime;

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
    IEnumerator NormalEvent()
    {
        imageNormal.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageNormal.SetActive(false);
    }
    IEnumerator HolidayEvent()
    {
        imageHoliday.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageHoliday.SetActive(false);
    }
    IEnumerator APoisonBEvent()
    {
        imageAPoisonB.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageAPoisonB.SetActive(false);
    }
    IEnumerator BPoisonAEvent()
    {
        imageBPoisonA.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageBPoisonA.SetActive(false);
    }
    IEnumerator FavourAEvent()
    {
        imageFavourA.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageFavourA.SetActive(false);
    }
    IEnumerator FavourBEvent()
    {
        imageFavourB.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageFavourB.SetActive(false);
    }
    IEnumerator SecretAEvent()
    {
        imageSecretA.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageSecretA.SetActive(false);
    }
    IEnumerator SecretBEvent()
    {
        imageSecretB.SetActive(true);
        yield return new WaitForSeconds(eventPopUpTime);
        imageSecretB.SetActive(false);
    }


    public void GetEvent()
    {
        int typeOfEvent = Random.Range(0, 2);

        if (typeOfEvent == 0)
        {
            EventStr = "Normal";
            GetRandomEvent(EventStr);
        }
        else if (typeOfEvent == 1)
        {
            EventStr = "Fire";
            GetRandomEvent(EventStr);
        }
        else if (typeOfEvent == 2)
        {
            EventStr = "Holiday";
            GetRandomEvent(EventStr);
        }
        else if (typeOfEvent == 3)
        {
            EventStr = "Poison";
            GetRandomEvent(EventStr);
        }
        else if (typeOfEvent == 4)
        {
            EventStr = "Favor";
            GetRandomEvent(EventStr);
        }
        else
        {
            EventStr = "Secret";
            GetRandomEvent(EventStr);
        }


    }

    public string GetEventString()
    {
        return EventStr;
    }

    public void GetRandomEvent(string eventName)
    {
        if (eventName == "Normal")
        {

            StartCoroutine(NormalEvent());

        }
        else if (eventName == "Fire")
        {

            if (factionRef.factionAAgression > factionRef.factionBAgression) // A setting fire on B
            {

                int moraleAmt = Random.Range(10, 30);
                int aggressionAmt = Random.Range(10, 30);

                // increase moral
                factionRef.IncreaseMorale("A", moraleAmt);
                factionRef.DecreaseMorale("B", moraleAmt);

                // decrease agression
                factionRef.DecreaseAgression("A", aggressionAmt);
                factionRef.IncreaseAgression("B", aggressionAmt);
                StartCoroutine(AFireBEvent());

            }

            else if (factionRef.factionAAgression <= factionRef.factionBAgression) // B setting fire on A
            {

                int moraleAmt = Random.Range(10, 30);
                int aggressionAmt = Random.Range(10, 30);

                // increase moral
                factionRef.IncreaseMorale("B", moraleAmt);
                factionRef.DecreaseMorale("A", moraleAmt);

                // decrease agression
                factionRef.DecreaseAgression("B", aggressionAmt);
                factionRef.IncreaseAgression("A", aggressionAmt);
                StartCoroutine(BFireAEvent());

            }

            else { }
        }
        else if (eventName == "Holiday") // for both 
        {

            int moraleAmt = Random.Range(5, 20);
            int aggressionAmt = Random.Range(5, 20);

            // increase moral
            factionRef.IncreaseMorale("A", moraleAmt);
            factionRef.IncreaseMorale("B", moraleAmt);

            // decrease agression
            factionRef.DecreaseAgression("A", aggressionAmt);
            factionRef.DecreaseAgression("B", aggressionAmt);
            StartCoroutine(HolidayEvent());

        }
        else if (eventName == "Poison")
        {
            if (factionRef.factionAAgression > factionRef.factionBAgression) // A poison to B
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 30);

                // increase moral
                factionRef.IncreaseMorale("A", moraleAmt);
                factionRef.DecreaseMorale("B", moraleAmt);

                // decrease agression
                factionRef.DecreaseAgression("A", aggressionAmt);
                factionRef.IncreaseAgression("B", aggressionAmt);
                StartCoroutine(APoisonBEvent());

            }

            else if (factionRef.factionAAgression <= factionRef.factionBAgression) // B poison to A
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 10);

                // increase moral
                factionRef.IncreaseMorale("B", moraleAmt);
                factionRef.DecreaseMorale("A", moraleAmt);

                // decrease agression
                factionRef.DecreaseAgression("B", aggressionAmt);
                factionRef.IncreaseAgression("A", aggressionAmt);
                StartCoroutine(BPoisonAEvent());

            }

            else { }


        }
        else if (eventName == "Favor")
        {
            if (factionRef.factionAMorale > factionRef.factionBMorale) // Favor A
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 10);

                // increase moral
                factionRef.IncreaseMorale("A"   , moraleAmt     );
                factionRef.DecreaseAgression("B", aggressionAmt );
                StartCoroutine(FavourAEvent());

            }

            else if (factionRef.factionAMorale <= factionRef.factionBMorale) // Favor B
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 10);

                // increase moral
                factionRef.IncreaseMorale("B"   , moraleAmt     );
                factionRef.DecreaseAgression("A", aggressionAmt );
                StartCoroutine(FavourBEvent());

            }

            else { }

        }
        else if (eventName == "Secret")
        {
            if (factionRef.factionAAgression > factionRef.factionBAgression) // Secret A
            {

                int moraleAmt = Random.Range(10, 20);
                int aggressionAmt = Random.Range(10, 20);

                // decrease moral
                factionRef.DecreaseMorale("A"   , moraleAmt);
                factionRef.IncreaseAgression("A", aggressionAmt);
                StartCoroutine(SecretAEvent());

            }

            else if (factionRef.factionAAgression <= factionRef.factionBAgression) // Secret B
            {

                int moraleAmt = Random.Range(10, 20);
                int aggressionAmt = Random.Range(10, 20);

                // decrease moral
                factionRef.DecreaseMorale("B"   , moraleAmt);
                factionRef.IncreaseAgression("B", aggressionAmt);
                StartCoroutine(SecretBEvent());

            }

            else { }

        }

        else { }

    }
}
