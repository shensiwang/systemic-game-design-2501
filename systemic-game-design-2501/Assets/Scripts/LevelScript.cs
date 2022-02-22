using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScript : MonoBehaviour
{
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
        Debug.Log(customerIsPresent);
        //Debug.Log(currentCustomerScript.finalDialogueString);

        numberOfCustomersLeft = totalCustomersPerDay - customersSucceeded - customersFailed;
        numberOfCustomersLeftUI.text = "Customers left: " + numberOfCustomersLeft;

        ReviewSheet();

        DisplayDialogue();

        reputationUI.text = "Reputation: " + RepManager.repMaster.reputationInGrade;
        dayCountUI.text = "Day: " + dayCount;


        ///---check for different scenarios like request succeed/fail or patience run out.---///

        if (customerIsPresent == true && currentCustomerScript.CurrentTimer <= 0)//Once the patience runs out
        {
            DespawnCustomer();
            customersFailed += 1;
            RepManager.repMaster.DecreaseRep(RepManager.repMaster.repReducedPercustomer); //decrease rep
            SpawnCustomer(); //only spawns when there is currently no customer & there are still remaining customers

        }

    }

    private void SpawnCustomer() //spawn customer 
    {
        if(customerIsPresent == false && numberOfCustomersLeft != 1) //make sure there is not currently a customer. make sure no more customers left.
        {
            Debug.Log("spawn");

            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            currentCustomerScript = currentCustomer.gameObject.GetComponent<Customer>();

            customerIsPresent = true;
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

    //when failed/passed, customers -1


    //when succeed RepManager.repMaster.IncreaseRep(10)
    //when fail RepManager.repMaster.DecreaseRep(10)

    private void ReviewSheet()
    {
        if(numberOfCustomersLeft == 0)
        {
            //display reviewsheet

            reviewSheetRequestSuccess.text = "Requests fulfilled: " + customersSucceeded + "/" + totalCustomersPerDay;

            reviewSheet.SetActive(true);
        }
    }

    private void CalculateTotalCustomersPerDay()
    {
        int random = Random.Range(2, 6);
        int amountChange = RepManager.repMaster.CustomerAmountChangedFromRep();

        //Debug.Log(amountChange);
        totalCustomersPerDay = random + amountChange;
    }

    private void ReviewSheetPerformance()
    {
        
    }

    private void DisplayDialogue()
    {
        dialogueUIText.text = currentCustomerScript.finalDialogueString;
    }
}
