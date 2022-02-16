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

       SpawnCustomer();


    }

    // Update is called once per frame
    void Update()
    {
        numberOfCustomersLeft = totalCustomersPerDay - customersSucceeded - customersFailed;
        numberOfCustomersLeftUI.text = "Customers left: " + numberOfCustomersLeft;

        ReviewSheet();

        //if(currentCustomerScript.cu)

        //patienceUI.fillAmount = (currentCustomerScript.CurrentTimer / currentCustomerScript.PatienceTimer); need to make customer current timer public

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


}
