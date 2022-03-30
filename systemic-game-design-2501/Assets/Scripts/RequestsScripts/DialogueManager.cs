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
    public Button dialogueBtn;
    public Image Arrow;
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
            Arrow.gameObject.SetActive(false);
            Dialogue.text = "";
            GameObject Customer = currentlevel.currentCustomer;
            dialogueBtn.interactable = false;
            if (Customer!=null)
            {
                CurrentCustomer = Customer.GetComponent<The_Customer>();
                CurrentCustomerScript = CurrentCustomer.CustomerScript;
            }
        }
        else
        {
            dialogueBtn.interactable = true;
            StartDialogue();
            if(sentenceLine==0)
            {
                Arrow.gameObject.SetActive(true);
            }
            else
            {
                Arrow.gameObject.SetActive(false);
            }
        }
    }

    public void StartDialogue()
    {
        Dialogue.text = CurrentCustomerScript[sentenceLine];
    }

    public void NextDialogue()
    {
        if(CurrentCustomer != null) 
        {
            if (sentenceLine < CurrentCustomerScript.Count - 1)
            {
                sentenceLine++;
                Dialogue.text = CurrentCustomerScript[sentenceLine];
            }
        }

    }

}
