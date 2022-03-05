using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private The_Customer CurrentCustomer;
    public Text Dialogue;
    private int sentenceLine = 0;
    private List<string> CurrentCustomerScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(CurrentCustomer==null)
        {
            sentenceLine = 0;
            Dialogue.text = "";
            GameObject Customer = GameObject.FindGameObjectWithTag("Customer");
            if (Customer!=null)
            {
                CurrentCustomer = Customer.GetComponent<The_Customer>();
                CurrentCustomerScript = CurrentCustomer.CustomerScript;
            }
        }
        else
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        Dialogue.text = CurrentCustomerScript[sentenceLine];
    }

    public void NextDialogue()
    {
        if(sentenceLine < CurrentCustomerScript.Count-1)
        {
            sentenceLine++;
            Dialogue.text = CurrentCustomerScript[sentenceLine];
        }

    }

}
