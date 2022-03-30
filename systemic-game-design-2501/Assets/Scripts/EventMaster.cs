using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Events Txt")]
    private TextMeshProUGUI AFactionMoral;
    private TextMeshProUGUI BFactionMoral;
    private TextMeshProUGUI AFactionAggression;
    private TextMeshProUGUI BFactionAggression;

    private TextMeshProUGUI AFactionMoral_Amt;
    private TextMeshProUGUI BFactionMoral_Amt;
    private TextMeshProUGUI AFactionAggression_Amt;
    private TextMeshProUGUI BFactionAggression_Amt;


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
        int typeOfEvent = Random.Range(0, 6);
        //int typeOfEvent = 1;

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

                // update customer feedback text
                DisplayAFactionMoral(moraleAmt, true, imageAFireB);
                DisplayAFactionAggression(aggressionAmt, false, imageAFireB);

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

                // update customer feedback text
                DisplayBFactionMoral(moraleAmt, true, imageBFireA);
                DisplayBFactionAggression(aggressionAmt, false, imageBFireA);

            }

            else { }
        }
        else if (eventName == "Holiday") // for both 
        {

            int moraleAmt = Random.Range(5, 10);
            int aggressionAmt = Random.Range(5, 20);

            // increase moral
            factionRef.IncreaseMorale("A", moraleAmt);
            factionRef.IncreaseMorale("B", moraleAmt);

            // decrease agression
            factionRef.DecreaseAgression("A", aggressionAmt);
            factionRef.DecreaseAgression("B", aggressionAmt);
            StartCoroutine(HolidayEvent());

            // update customer feedback text
            DisplayAFactionMoral(moraleAmt, true, imageHoliday);
            DisplayAFactionAggression(aggressionAmt, false, imageHoliday);

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

                // update customer feedback text
                DisplayAFactionMoral(moraleAmt, true, imageAPoisonB);
                DisplayAFactionAggression(aggressionAmt, false, imageAPoisonB);

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

                // update customer feedback text
                DisplayBFactionMoral(moraleAmt, true, imageBPoisonA);
                DisplayBFactionAggression(aggressionAmt, false, imageBPoisonA);

            }

            else { }


        }
        else if (eventName == "Favor")
        {
            if (factionRef.factionAMorale <= factionRef.factionBMorale) // Favor A
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 10);

                // increase moral
                factionRef.IncreaseMorale("A"   , moraleAmt     );
                factionRef.DecreaseAgression("B", aggressionAmt );
                StartCoroutine(FavourAEvent());

                // update customer feedback text
                DisplayAFactionMoral(moraleAmt, true, imageFavourA);
                DisplayBFactionAggression(aggressionAmt, false, imageFavourA);

            }

            else if (factionRef.factionAMorale > factionRef.factionBMorale) // Favor B
            {

                int moraleAmt = Random.Range(5, 10);
                int aggressionAmt = Random.Range(5, 10);

                // increase moral
                factionRef.IncreaseMorale("B"   , moraleAmt     );
                factionRef.DecreaseAgression("A", aggressionAmt );
                StartCoroutine(FavourBEvent());

                // update customer feedback text
                DisplayBFactionMoral(moraleAmt, true, imageFavourB);
                DisplayAFactionAggression(aggressionAmt, false, imageFavourB);

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

                // update customer feedback text
                DisplayAFactionMoral(moraleAmt, false, imageSecretA);
                DisplayAFactionAggression(aggressionAmt, true, imageSecretA);

            }

            else if (factionRef.factionAAgression <= factionRef.factionBAgression) // Secret B
            {

                int moraleAmt = Random.Range(10, 20);
                int aggressionAmt = Random.Range(10, 20);

                // decrease moral
                factionRef.DecreaseMorale("B"   , moraleAmt);
                factionRef.IncreaseAgression("B", aggressionAmt);
                StartCoroutine(SecretBEvent());

                // update customer feedback text
                DisplayBFactionMoral(moraleAmt, false, imageSecretB);
                DisplayBFactionAggression(aggressionAmt, true, imageSecretB);

            }

            else { }

        }

        else { }

    }

    private void DisplayAFactionMoral(float AMoral, bool Afaction, GameObject Event)
    {
        AFactionMoral = Event.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        AFactionMoral_Amt = Event.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        if (Afaction)
        {
            AFactionMoral.text = "A Morale";
            AFactionMoral.color = Color.green;
            AFactionMoral_Amt.text = "+ " + AMoral;
            AFactionMoral_Amt.color = Color.green;
        }
        else 
        {
            AFactionMoral.text = "A Morale";
            AFactionMoral.color = Color.red;
            AFactionMoral_Amt.text = "- " + AMoral;
            AFactionMoral_Amt.color = Color.red;
        }
    }

    private void DisplayBFactionMoral(float BMoral, bool Bfaction, GameObject Event)
    {
        BFactionMoral = Event.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        BFactionMoral_Amt = Event.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        if (Bfaction)
        {
            BFactionMoral.text = "B Morale";
            BFactionMoral.color = Color.green;
            BFactionMoral_Amt.text = "+ " + BMoral;
            BFactionMoral_Amt.color = Color.green;
        }
        else
        {
            BFactionMoral.text = "B Morale";
            BFactionMoral.color = Color.red;
            BFactionMoral_Amt.text = "- " + BMoral;
            BFactionMoral_Amt.color = Color.red;
        }
    }

    private void DisplayAFactionAggression(float AAggression, bool Afaction, GameObject Event)
    {
        AFactionAggression = Event.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        AFactionAggression_Amt = Event.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        if (Afaction)
        {
            AFactionAggression.text = "A Aggression";
            AFactionAggression.color = Color.green;
            AFactionAggression_Amt.text = "+ " + AAggression;
            AFactionAggression_Amt.color = Color.green;
        }
        else
        {
            AFactionAggression.text = "A Aggression";
            AFactionAggression.color = Color.red;
            AFactionAggression_Amt.text = "- " + AAggression;
            AFactionAggression_Amt.color = Color.red;
        }
    }

    private void DisplayBFactionAggression(float BAggression, bool Bfaction, GameObject Event)
    {
        BFactionAggression = Event.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        BFactionAggression_Amt = Event.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        if (Bfaction)
        {
            BFactionAggression.text = "B Aggression";
            BFactionAggression.color = Color.green;
            BFactionAggression_Amt.text = "+ " + BAggression;
            BFactionAggression_Amt.color = Color.green;
        }
        else
        {
            BFactionAggression.text = "B Aggression";
            BFactionAggression.color = Color.red;
            BFactionAggression_Amt.text = "- " + BAggression;
            BFactionAggression_Amt.color = Color.red;
        }
    }
}
