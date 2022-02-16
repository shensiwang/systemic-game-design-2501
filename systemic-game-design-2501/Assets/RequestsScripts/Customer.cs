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

    [Header("-----------Easygoing Dialogue--------------")]
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

    [Header("-----------Super Red Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] WarSurgeDialogue;
    [TextArea(5, 5)]
    public string[] DragonicShellDialogue;
    [TextArea(5, 5)]
    public string[] DivineScryerDialogue;
    [TextArea(5, 5)]
    public string[] HerculeanSerumDialogue;
    [TextArea(5, 5)]
    public string[] SalamandersBaitDialogue;


    [Header("-----------Super Blue Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] WizardsBrewDialogue;
    [TextArea(5, 5)]
    public string[] AqeuousFromeDialogue;
    [TextArea(5, 5)]
    public string[] PotionOfPremonitionDialogue;
    [TextArea(5, 5)]
    public string[] KnowledgeMeadDialogue;
    [TextArea(5, 5)]
    public string[] RusalkasCallDialogue;


    [Header("-----------Super Yellow Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] TouchOfWondermentDialogue;
    [TextArea(5, 5)]
    public string[] NarcissusBlendDialogue;
    [TextArea(5, 5)]
    public string[] FortuitousVisionsDialogue;
    [TextArea(5, 5)]
    public string[] PinchOfErosDialogue;
    [TextArea(5, 5)]
    public string[] ToadstoolEssenceDialogue;


    [Header("-----------Green Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] VerdantRejuvenationDialogue;
    [TextArea(5, 5)]
    public string[] FrogificationDialogue;
    [TextArea(5, 5)]
    public string[] WoodlandWhispersDialogue;
    [TextArea(5, 5)]
    public string[] DomainOfSeclusionDialogue;
    [TextArea(5, 5)]
    public string[] DryadsOfferingDialogue;


    [Header("-----------Orange Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] AutoRepairDialogue;
    [TextArea(5, 5)]
    public string[] FormeOfTheMarionetteDialogue;
    [TextArea(5, 5)]
    public string[] RetraceMachinationDialogue;
    [TextArea(5, 5)]
    public string[] FeatheredStepsDialogue;
    [TextArea(5, 5)]
    public string[] SoulInstallDialogue;


    [Header("-----------Purple Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] CalmOfTheDeadDialogue;
    [TextArea(5, 5)]
    public string[] PerceptualArrayDialogue;
    [TextArea(5, 5)]
    public string[] DeadmansTongueDialogue;
    [TextArea(5, 5)]
    public string[] GazeOfTheOutersideDialogue;
    [TextArea(5, 5)]
    public string[] SolomonsBloodDialogue;

    [Header("-----------Misc--------------")]
    public float PatienceTimer;
    private float CurrentTimer = 0;
    private float repPatienceTimerIncrement = 0;
    public int repReducePerCustomer = 4;

    private void Start()
    {

        int ageRandomizer = Random.Range(0, 2);
        int fickleRandomizer = Random.Range(0, 2);
        int BaseRandomizer = Random.Range(0, 5);
        int ElementRandomizer1 = Random.Range(0, 3);
        int ElementRandomizer2 = Random.Range(0, 3);

        // update customer patient timer according to current reputation
        repPatienceTimerIncrement = RepManager.repMaster.CustomerRepTimeIncreasement();

        if (ageRandomizer == 0)
        {
            Age = new Old();
        }
        else
        {
            Age = new Young();
        }
        PatienceTimer = Age.getTimeLimit() + repPatienceTimerIncrement;

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
            switch (BaseNeeded.getType())
            {
                case "Amelioration":
                    if(MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, WarSurgeDialogue.Length);
                        Debug.Log(WarSurgeDialogue[randomizedLine]);
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, WizardsBrewDialogue.Length);
                        Debug.Log(WizardsBrewDialogue[randomizedLine]);
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, TouchOfWondermentDialogue.Length);
                        Debug.Log(TouchOfWondermentDialogue[randomizedLine]);
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, VerdantRejuvenationDialogue.Length);
                        Debug.Log(VerdantRejuvenationDialogue[randomizedLine]);
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, AutoRepairDialogue.Length);
                        Debug.Log(AutoRepairDialogue[randomizedLine]);
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, CalmOfTheDeadDialogue.Length);
                        Debug.Log(CalmOfTheDeadDialogue[randomizedLine]);
                    }
                    break;
                case "Mutation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, DragonicShellDialogue.Length);
                            Debug.Log(DragonicShellDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, AqeuousFromeDialogue.Length);
                            Debug.Log(AqeuousFromeDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, NarcissusBlendDialogue.Length);
                            Debug.Log(NarcissusBlendDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, FrogificationDialogue.Length);
                            Debug.Log(FrogificationDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, FormeOfTheMarionetteDialogue.Length);
                            Debug.Log(FormeOfTheMarionetteDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, PerceptualArrayDialogue.Length);
                            Debug.Log(PerceptualArrayDialogue[randomizedLine]);
                        }
                    }
                    break;
                case "Haruspical":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, DivineScryerDialogue.Length);
                            Debug.Log(DivineScryerDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, PotionOfPremonitionDialogue.Length);
                            Debug.Log(PotionOfPremonitionDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, FortuitousVisionsDialogue.Length);
                            Debug.Log(FortuitousVisionsDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, WoodlandWhispersDialogue.Length);
                            Debug.Log(WoodlandWhispersDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, RetraceMachinationDialogue.Length);
                            Debug.Log(RetraceMachinationDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, DeadmansTongueDialogue.Length);
                            Debug.Log(DeadmansTongueDialogue[randomizedLine]);
                        }
                    }
                    break;
                case "Emanation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, HerculeanSerumDialogue.Length);
                            Debug.Log(HerculeanSerumDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, KnowledgeMeadDialogue.Length);
                            Debug.Log(KnowledgeMeadDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, PinchOfErosDialogue.Length);
                            Debug.Log(PinchOfErosDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, DomainOfSeclusionDialogue.Length);
                            Debug.Log(DomainOfSeclusionDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, FeatheredStepsDialogue.Length);
                            Debug.Log(FeatheredStepsDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, GazeOfTheOutersideDialogue.Length);
                            Debug.Log(GazeOfTheOutersideDialogue[randomizedLine]);
                        }
                    }
                    break;
                case "Evocation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, SalamandersBaitDialogue.Length);
                            Debug.Log(SalamandersBaitDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, RusalkasCallDialogue.Length);
                            Debug.Log(RusalkasCallDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0,ToadstoolEssenceDialogue.Length);
                            Debug.Log(ToadstoolEssenceDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, DryadsOfferingDialogue.Length);
                            Debug.Log(DryadsOfferingDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, SoulInstallDialogue.Length);
                            Debug.Log(SoulInstallDialogue[randomizedLine]);
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, SolomonsBloodDialogue.Length);
                            Debug.Log(SolomonsBloodDialogue[randomizedLine]);
                        }
                    }
                    break;
            }
        }
        //if (Fickleness.IsFickle() == true)
        //{
        //    Debug.Log("Base Ingredient: " + BaseNeeded.getType() + ", Element: " + MainElement.getName() + ", Randomized 1: " + ElementRandomizer1 + ", Randomized 2: " + ElementRandomizer2);
        //}
        //else
        //{
        //    Debug.Log("Base Ingredient: " + BaseNeeded.getType());
        //}

     

    }

    private void Update()
    {
        CurrentTimer += Time.deltaTime;
        if(CurrentTimer>=PatienceTimer)//Once the patience runs out
        {
            CurrentTimer = 0;
            this.gameObject.SetActive(false);

            //TODO: update rep heres (NEGATIVE)
            RepManager.repMaster.DecreaseRep(repReducePerCustomer);

        }
    }


}
