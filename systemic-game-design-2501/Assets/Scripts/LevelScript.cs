using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public GameObject customerPrefab;

    public GameObject currentCustomer;
    public Transform customerSpawnPoint;

    public int totalCustomersPerDay;

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
        
    }

    private void SpawnCustomer() //spawn customer 
    {
        if(customerIsPresent == false)
        {
            currentCustomer = Instantiate(customerPrefab, customerSpawnPoint);
            customerIsPresent = true;
        }
    }
}
