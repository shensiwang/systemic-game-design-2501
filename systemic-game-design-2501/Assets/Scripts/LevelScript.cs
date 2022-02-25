using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScript : MonoBehaviour
{
    public Slots completedPotion; //use to check for potion brewed.

    public int dayCount = 1;

    public int customersSucceeded;
    public int customersFailed;

    public GameObject reviewSheet;
    

    public GameObject customerPrefab;
    public GameObject currentCustomer;

    private Customer currentCustomerScript;
    public Transform customerSpawnPoint;

    public int totalCustomersPerDay;
    private int numberOfCustomersLeft;

    [Header("UI Elements")]
    public TextMeshProUGUI numberOfCustomersLeftUI;
    public TextMeshProUGUI reputationUI;
    public TextMeshProUGUI dayCountUI;

    public TextMeshProUGUI dialogueUIText;

    public TextMeshProUGUI reviewSheetRequestSuccess;

    

    private bool customerIsPresent = false; //check whether there is currently a customer
    private bool currentCustomerServed = false;

    // Start is called before the first frame update
    void Start()
    {
        CalculateTotalCustomersPerDay();
        numberOfCustomersLeft = totalCustomersPerDay;

        SpawnCustomer();
        


    }

    // Update is called once per frame
    void Update()
    {
       
        //Debug.Log(currentCustomerScript.finalDialogueString);

        numberOfCustomersLeft = totalCustomersPerDay - customersSucceeded - customersFailed;
        numberOfCustomersLeftUI.text = "Customers left: " + numberOfCustomersLeft;

        ReviewSheet();

        DisplayDialogue();

        reputationUI.text = "Reputation: " + RepManager.repMaster.reputationInGrade;
        dayCountUI.text = "Day: " + dayCount;


        ///---check for different scenarios like request succeed/fail or patience run out.---///

        if (customerIsPresent == true && currentCustomerServed == false && currentCustomerScript.CurrentTimer <= 0)//Once the patience runs out
        {
            DespawnCustomer();
            customersFailed += 1;
            RepManager.repMaster.DecreaseRep(RepManager.repMaster.repReducedPercustomer); //decrease rep
            StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers

            Debug.Log("customer failed due to time");

        }

    }

    //CUSTOMER SPAWNING AND DESPAWNING//

    private void SpawnCustomer() //spawn customer 
    {
        if(customerIsPresent == false && numberOfCustomersLeft != 1) //make sure there is not currently a customer. make sure no more customers left.
        {
            Debug.Log("spawn");

            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            currentCustomerScript = currentCustomer.gameObject.GetComponent<Customer>();

            customerIsPresent = true;
            currentCustomerServed = false;
        }
    }

    private void DespawnCustomer()
    {
        if(customerIsPresent == true)
        {
            Destroy(currentCustomer); //or whatever code to remove the customer
            customerIsPresent = false;
        }
    }

    IEnumerator DelayedDespawn() //delay added to check for patience first, before despawning it.
    {
        if (customerIsPresent == true)
        {
            yield return new WaitForSeconds(.1f);
            Destroy(currentCustomer); //or whatever code to remove the customer
            customerIsPresent = false;
        }
    }

    IEnumerator DelayedSpawn() //delay added to allow for despawning first (since that was delayed, this needs to be delayed too)
    {
        yield return new WaitForSeconds(.1f);

        if (customerIsPresent == false && numberOfCustomersLeft != 0) //make sure there is not currently a customer. make sure no more customers left.
        {
            Debug.Log("delyaedspawn");

            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            currentCustomerScript = currentCustomer.gameObject.GetComponent<Customer>();

            customerIsPresent = true;
            currentCustomerServed = false;
        }
    }

    //CUSTOMER SPAWN AMOUNT//

    private void CalculateTotalCustomersPerDay()
    {
        int random = Random.Range(2, 6);
        int amountChange = RepManager.repMaster.CustomerAmountChangedFromRep();

        //Debug.Log(amountChange);
        totalCustomersPerDay = random + amountChange;
    }

    //REVIEW SHEET//

    private void ReviewSheet()
    {
        if(numberOfCustomersLeft == 0)
        {
            //display reviewsheet

            reviewSheetRequestSuccess.text = "Requests fulfilled: " + customersSucceeded + "/" + totalCustomersPerDay;

            reviewSheet.SetActive(true);
        }
    }

    private void ReviewSheetPerformance()
    {

    }

    

    

    //DISPLAYING DIALOGUE//

    private void DisplayDialogue()
    {
        dialogueUIText.text = currentCustomerScript.finalDialogueString;
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
            if (currentCustomerScript.Fickleness.IsFickle())
            {
                if (CheckPotionElement() == true && CheckPotionType() == true)  //correct potion
                {
                    StartCoroutine(DelayedDespawn());
                    customersSucceeded += 1;
                    RepManager.repMaster.IncreaseRep(5); //
                    

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    Debug.Log("Correct Potion");

                     StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers

                }
                else
                {
                    StartCoroutine(DelayedDespawn());
                    customersFailed += 1;
                    RepManager.repMaster.DecreaseRep(RepManager.repMaster.repReducedPercustomer);
                    
                    Debug.Log("Wrong Potion");

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers
                }
            }
            else
            {
                if (CheckPotionType() == true)  //correct potion
                {
                    StartCoroutine(DelayedDespawn());
                    customersSucceeded += 1;
                    RepManager.repMaster.IncreaseRep(5); //
                    

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    Debug.Log("Correct Potion");

                    StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers

                }
                else
                {
                    StartCoroutine(DelayedDespawn());
                    customersFailed += 1;
                    RepManager.repMaster.DecreaseRep(RepManager.repMaster.repReducedPercustomer);
                    
                    Debug.Log("Wrong Potion");

                    completedPotion.potionType = null;
                    completedPotion.potionElement = null;
                    completedPotion.gameObject.SetActive(false);

                    StartCoroutine(DelayedSpawn()); //only spawns when there is currently no customer & there are still remaining customers
                }
            }
            
            
        }
    }
}
