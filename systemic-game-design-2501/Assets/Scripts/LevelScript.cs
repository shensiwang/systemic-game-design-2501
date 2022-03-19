using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScript : MonoBehaviour
{

    [Header("Game Info")]
    public bool lose = false;
    public int dayCount = 1;

    [Header("References to scripts")]
    public Faction faction;
    //public ReceipeManager rm;
    public StartDayManager startDayManagerRef;
    public IngredientManager ingredientManagerRef;

    public Slots completedPotion; //use to check for potion brewed.
    //public int customersSucceeded;
    //public int customersFailed;

    //public GameObject reviewSheet;
    public EndDayManager endDayReport;
    
    [Header("Customer")]
    public GameObject customerPrefab;
    public GameObject currentCustomer;

    public The_Customer currentCustomerScript;
    public Transform customerSpawnPoint;

    public float customerInterval; //used to despawn customers after this amount of time
    public float currentCustomerInterval;

    [Header("Customer Amount")]
    public int totalCustomersPerDay = 2;
    public int numberOfCustomersLeft;

    [Header("UI Elements")]
    //public TextMeshProUGUI numberOfCustomersLeftUI;
    //public TextMeshProUGUI reputationUI;
    public TextMeshProUGUI dayCountUI;
    public TextMeshProUGUI dialogueUIText;

    [Header("Floating Text")]
    public TextMeshProUGUI moneyEarned;

    public AudioClip doorBell;
    public AudioClip paymentSFX;
    public AudioSource audioSource;

    //public TextMeshProUGUI reviewSheetRequestSuccess;



    private bool customerIsPresent = false; //check whether there is currently a customer
    private bool currentCustomerServed = false;

    void Start()
    {
        startDayManagerRef.CallDayMorning();
        audioSource.clip = doorBell;
    }

    void Update()
    {

        //Debug.Log(currentCustomerScript.finalDialogueString);

        //numberOfCustomersLeft = totalCustomersPerDay - customersSucceeded - customersFailed;
        //numberOfCustomersLeftUI.text = "Customers left: " + numberOfCustomersLeft;
        //reputationUI.text = "Reputation: " + RepManager.repMaster.reputationInGrade;
        //dayCountUI.text = "Day: " + dayCount;
        //ReviewSheet();
        //DELETED CAUSE OF CHANGES

        if (!lose)
        {
            //DisplayDialogue();

            currentCustomerInterval -= Time.deltaTime;


            ///---check if timer ran out. To allow game to pregress without player input---///

            if (customerIsPresent == true && currentCustomerInterval <= 0)//despawn after certain amount of time, To allow game to pregress without player input
            {
                faction.DecreaseAgression(currentCustomerScript.Faction);
                faction.DecreaseLoyalty(currentCustomerScript.Faction);

                DespawnCustomer();

                StartCoroutine(DelayedSpawn()); 

                currentCustomerInterval = customerInterval; //reset timer

                Debug.Log("customer failed due to time");

            }

            if(numberOfCustomersLeft == 0)
            {
                //move to next day

                startDayManagerRef.CallDayMorning();

                dayCount += 1;

            }

            dayCountUI.text = "Day: " + dayCount; //update day counter
        }

        

    }

    //CUSTOMER SPAWNING AND DESPAWNING//

    public void SpawnCustomer() //spawn customer 
    {
        if (!lose)
        {
            if (customerIsPresent == false && numberOfCustomersLeft != 0) //make sure there is not currently a customer. 
            {
                //Player Doorbell SFX
                audioSource.clip = doorBell;
                audioSource.enabled = true;
                audioSource.Play(); 
                
                Debug.Log("spawn");

                currentCustomerInterval = customerInterval;

                currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
                currentCustomerScript = currentCustomer.gameObject.GetComponent<The_Customer>();

                if(numberOfCustomersLeft == 2) currentCustomerScript.Faction = "A"; //FIRST CUSTOMER IS FROM FACTION A
                else if(numberOfCustomersLeft == 1) currentCustomerScript.Faction = "B"; //SECOND CUSTOMER IS FROM FACTION B

                customerIsPresent = true;
                currentCustomerServed = false;

                
            }
            
        }
        
    }
    IEnumerator DelayedSpawn() //delay added to allow for despawning first (since that was delayed, this needs to be delayed too)
    {
        yield return new WaitForSeconds(.1f);

        if (customerIsPresent == false && numberOfCustomersLeft != 0) //make sure there is not currently a customer. make sure no more customers left.
        {
            //Player Doorbell SFX
            audioSource.clip = doorBell;
            audioSource.Play();

            Debug.Log("delyaedspawn");

            currentCustomerInterval = customerInterval;

            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            currentCustomerScript = currentCustomer.gameObject.GetComponent<The_Customer>();

            if (numberOfCustomersLeft == 2) currentCustomerScript.Faction = "A"; //FIRST CUSTOMER IS FROM FACTION A
            else if (numberOfCustomersLeft == 1) currentCustomerScript.Faction = "B"; //SECOND CUSTOMER IS FROM FACTION B

            customerIsPresent = true;
            currentCustomerServed = false;

            //numberOfCustomersLeft -= 1;
        }
    }
    private void DespawnCustomer()
    {
        if (!lose)
        {
            if (customerIsPresent == true)
            {
                Destroy(currentCustomer); //or whatever code to remove the customer
                numberOfCustomersLeft -= 1;
                customerIsPresent = false;
            }
        }
    }

    IEnumerator DelayedDespawn() //delay added to check for patience first, before despawning it.
    {
        if (customerIsPresent == true)
        {
            yield return new WaitForSeconds(.1f);
            Destroy(currentCustomer); //or whatever code to remove the customer
            numberOfCustomersLeft -= 1;
            customerIsPresent = false;
        }
    }

    

    //CUSTOMER SPAWN AMOUNT//

    /*
    public void CalculateTotalCustomersPerDay()
    {
        int random = Random.Range(2, 6);
        int amountChange = RepManager.repMaster.CustomerAmountChangedFromRep();

        //Debug.Log(amountChange);
        totalCustomersPerDay = random + amountChange;
    }
    */

    //REVIEW SHEET//

    private void ReviewSheet()
    {
        if(numberOfCustomersLeft == 0 && !endDayReport.dayEnded)
        {
            //display reviewsheet
            //reviewSheetRequestSuccess.text = "Requests fulfilled: " + customersSucceeded + "/" + totalCustomersPerDay;
            //reviewSheet.SetActive(true);

            endDayReport.CallEndDay();
            endDayReport.dayEnded = true;
        }
    }

    private void ReviewSheetPerformance()
    {

    }

    

    

    //DISPLAYING DIALOGUE//

    private void DisplayDialogue()
    {
        dialogueUIText.text = currentCustomerScript.CustomerScript[0] + "\n" + currentCustomerScript.CustomerScript[1];

        if(currentCustomerScript == null)
        {
            dialogueUIText.text = "";
        }
    }



    //SELLING AND CHECKING FOR CORRECT POTION//
    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// 
    
    public bool CheckPotionType() //if same request base type is same as completedpotion base type, return true.
    {
        if(currentCustomerScript.BaseNeeded.getType() == completedPotion.potionType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckPotionElement() //if same request element is same as completedpotion element, return true.
    {
        if (currentCustomerScript.MainElement.getName() == completedPotion.potionElement)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SellPotion()
    {
        currentCustomerServed = true;

        if (customerIsPresent == true)
        {
            /*
            if (currentCustomerScript.Fickleness.IsFickle())
            {
                if (CheckPotionElement() == true && CheckPotionType() == true)  //correct potion
                {
                    StartCoroutine(DelayedDespawn());
                    
                    
                    //customersSucceeded += 1;
                    //add changes to rep or money here//
                    //RepManager.repMaster.IncreaseRep(5); 
                    //

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    Debug.Log("Correct Potion");

                     StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers

                }
                else
                {
                    StartCoroutine(DelayedDespawn());
                   
                    //customersFailed += 1;
                    //add changes to rep or money here//
                    //RepManager.repMaster.DecreaseRep(RepManager.repMaster.repReducedPercustomer);
                    //
                    
                    Debug.Log("Wrong Potion");

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers
                }
            }
            else

            */
            
                if (CheckPotionType() == true)  //CORRECT potion
                {
                    StartCoroutine(DelayedDespawn());

                //EARN MONEY//
                if (currentCustomerScript.willPay == true)
                {
                    ingredientManagerRef.CalculateDailySales(currentCustomerScript.percentagePaid);
                    StartCoroutine(moneyEarnedFloatingText(3f));

                    //Player Money SFX
                    audioSource.clip = paymentSFX;
                    audioSource.Play();
                }
                

                //CHANGE FACTION STATS//

                //increase aggression of faction.
                faction.IncreaseAgression(currentCustomerScript.Faction);

                //increase loyalty of faction. decrease loyalty of opposing faction.
                faction.IncreaseLoyalty(currentCustomerScript.Faction); 
                faction.DecreaseLoyalty(currentCustomerScript.oppFaction); 

                //reset completed potion

                completedPotion.potionType = null;
                completedPotion.potionElement = null;
                completedPotion.gameObject.SetActive(false);

                //Destroy(rm.potionPrefab); //added for placeholder

                Debug.Log("Correct Potion");

                StartCoroutine(DelayedSpawn()); 

                }
                else //WRONG POTION
                {

                //decrease loyalty of faction.
                //faction.DecreaseAgression(currentCustomerScript.Faction);
                faction.DecreaseLoyalty(currentCustomerScript.Faction);

                StartCoroutine(DelayedDespawn());
                    
                Debug.Log("Wrong Potion");

                completedPotion.potionType = null;
                completedPotion.potionElement = null;
                completedPotion.gameObject.SetActive(false);

                //Destroy(rm.potionPrefab); //added for placeholder

                StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers

                StartCoroutine(noMoneyEarnedFloatingText(3F));
                }
            
            
            
        }
    }

    public void Lose()
    {
        //lose
        //Lose pop up

        lose = true;
    }

    IEnumerator moneyEarnedFloatingText(float time)
    {
        moneyEarned.text = "+ $ " + ingredientManagerRef.CalculateDailySales(currentCustomerScript.percentagePaid);
        moneyEarned.color = Color.red;
        moneyEarned.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        moneyEarned.gameObject.SetActive(false);
    }

    IEnumerator noMoneyEarnedFloatingText(float time) 
    {
        moneyEarned.text = "Wrong Potion  No Money ! ";
        moneyEarned.color = Color.green;
        moneyEarned.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        moneyEarned.gameObject.SetActive(false);
    }
}
