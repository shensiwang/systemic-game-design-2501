using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScript : MonoBehaviour
{
    //public int DaysPassed;

    public GameObject reviewSheet;

    public Image patienceUI;

    public GameObject customerPrefab;

    public GameObject currentCustomer;
    private Customer currentCustomerScript;

    public Transform customerSpawnPoint;

    public int totalCustomersPerDay;
    private int numberOfCustomersLeft;

    public TextMeshProUGUI numberOfCustomersLeftUI;

    public int customersSucceeded;
    public int customersFailed;

    private bool customerIsPresent = false; //check whether there is currently a customer

    // Start is called before the first frame update
    void Start()
    {

       CalculateTotalCustomersPerDay();

       SpawnCustomer();

        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCustomersLeft = totalCustomersPerDay - customersSucceeded - customersFailed;
        numberOfCustomersLeftUI.text = "Customers left: " + numberOfCustomersLeft;

        ReviewSheet();

        if (currentCustomerScript.CurrentTimer <= 0)//Once the patience runs out
        {
            DespawnCustomer();
            RepManager.repMaster.DecreaseRep(currentCustomerScript.repReducePerCustomer); //decrease rep when customer runs out of patience

        }

    }

    private void SpawnCustomer() //spawn customer 
    {
        if(customerIsPresent == false)
        {
            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            customerIsPresent = true;

            currentCustomerScript = currentCustomer.gameObject.GetComponent<Customer>();
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


}
