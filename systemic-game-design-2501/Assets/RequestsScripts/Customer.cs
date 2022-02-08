using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AgeInterface Age;
    public FicklnessInterface Fickleness;
    public BaseInterface BaseNeeded;
    public ElementInterface FirstElement;
    public ElementInterface MainElement;
    public ElementInterface SecondElement;

    [TextArea(5,5)]
    public string[] AnyBaseAmeliorationDialogue;
    [TextArea(5, 5)]
    public string[] AnyBaseMutationDialogue;
    [TextArea(5, 5)]
    public string[] AnyBaseHaruspicalDialogue;
    [TextArea(5, 5)]
    public string[] AnyBaseEmantionDialogue;
    [TextArea(5, 5)]
    public string[] AnyBaseEvocationDialogue;

   
    public float PatienceTimer;
    private float CurrentTimer = 0;

    private void Start()
    {

        int ageRandomizer = Random.Range(0, 2);
        int fickleRandomizer = Random.Range(0, 2);
        int BaseRandomizer = Random.Range(0, 5);
        int ElementRandomizer1 = Random.Range(0, 3);
        int ElementRandomizer2 = Random.Range(0, 3);
       
        if (ageRandomizer == 0)
        {
            Age = new Old();
        }
        else
        {
            Age = new Young();
        }
        PatienceTimer = Age.getTimeLimit();

        if (fickleRandomizer == 0)
        {
            Fickleness = new Precise();
        }
        else
        {
            Fickleness = new EasyGoing();
        }

        switch (BaseRandomizer)
        {
            case 0:
                BaseNeeded = new Amelioration();
                break;
            case 1:
                BaseNeeded = new Mutation();
                break;
            case 2:
                BaseNeeded = new Haruspical();
                break;
            case 3:
                BaseNeeded = new Emanation();
                break;
            case 4:
                BaseNeeded = new Evocation();
                break;
        }

        Debug.Log("I'm " + Age.getAge() + " and I am " + Fickleness);

        if (Fickleness.IsFickle() == false)
        {
            if (BaseNeeded.getType() == "Amelioration")
            {
                int randomizedLine = Random.Range(0, AnyBaseAmeliorationDialogue.Length);
                Debug.Log(AnyBaseAmeliorationDialogue[randomizedLine]);
            }
            else if (BaseNeeded.getType() == "Mutation")
            {
                int randomizedLine = Random.Range(0, AnyBaseMutationDialogue.Length);
                Debug.Log(AnyBaseMutationDialogue[randomizedLine]);
            }
            else if (BaseNeeded.getType() == "Haruspical")
            {
                int randomizedLine = Random.Range(0, AnyBaseHaruspicalDialogue.Length);
                Debug.Log(AnyBaseHaruspicalDialogue[randomizedLine]);
            }
            else if (BaseNeeded.getType() == "Emanation")
            {
                int randomizedLine = Random.Range(0, AnyBaseEmantionDialogue.Length);
                Debug.Log(AnyBaseEmantionDialogue[randomizedLine]);
            }
            else if (BaseNeeded.getType() == "Evocation")
            {
                int randomizedLine = Random.Range(0, AnyBaseEvocationDialogue.Length);
                Debug.Log(AnyBaseEvocationDialogue[randomizedLine]);
            }
            else
            {
                Debug.Log("ERROR. INCORRECT BASE");
            }
        }
        else
        {
            switch (ElementRandomizer1)
            {
                case 0://Main element is red
                    MainElement = new Red();
                    break;
                case 1://Main element is blue
                    MainElement = new Blue();
                    break;
                case 2://main element is yellow
                    MainElement = new Yellow();
                    break;
            }
            FirstElement = MainElement;

            switch (ElementRandomizer2)
            {
                case 0://When second element is red
                    MainElement = MainElement.AddedWithRed();
                    SecondElement = new Red();
                    break;

                case 1://when second element is blue
                    MainElement = MainElement.AddedWithBlue();
                    SecondElement = new Blue();
                    break;

                case 2://when second element is yellow
                    MainElement = MainElement.AddedWithYellow();
                    SecondElement = new Yellow();
                    break;
            }
            Debug.Log("This customer wants a " + MainElement.PotionName(BaseNeeded));

        }
        if (Fickleness.IsFickle() == true)
        {
            Debug.Log("Base Ingredient: " + BaseNeeded.getType() + ", Element: " + MainElement.getName() + ", Randomized 1: " + ElementRandomizer1 + ", Randomized 2: " + ElementRandomizer2);
        }
        else
        {
            Debug.Log("Base Ingredient: " + BaseNeeded.getType());
        }

     

    }

    private void Update()
    {
        CurrentTimer += Time.deltaTime; 
        if(CurrentTimer>=PatienceTimer)//Once the patience runs out
        {
            CurrentTimer = 0;
            this.gameObject.SetActive(false);
            //TODO: update rep & currency heres (NEGATIVE)
        }
    }


}
