using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private The_Customer CurrentCustomer;
    public TextMeshProUGUI Dialogue;
    private int sentenceLine = 0;
    private List<string> CurrentCustomerScript;
    private LevelScript currentlevel;
    void Start()
    {
        currentlevel = GameObject.FindObjectOfType<LevelScript>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CurrentCustomer==null)
        {
            sentenceLine = 0;
            Dialogue.text = "";
            GameObject Customer = currentlevel.currentCustomer;
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
