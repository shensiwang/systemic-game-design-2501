using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public AgeInterface Age;
    public FicklnessInterface Fickleness;
    public BaseInterface BaseNeeded;
    public ElementInterface FirstElement;
    public ElementInterface MainElement;
    public ElementInterface SecondElement;

    public string finalDialogueString; //added to access this variable and display it

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
    public float CurrentTimer;
    public float repPatienceTimerIncrement = 0;
    public int repReducePerCustomer = 4;

    [Header("-----------UI--------------")]
    public Image patienceUI;

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
        CurrentTimer = PatienceTimer;

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
                finalDialogueString = AnyBaseAmeliorationDialogue[randomizedLine];
            }
            else if (BaseNeeded.getType() == "Mutation")
            {
                int randomizedLine = Random.Range(0, AnyBaseMutationDialogue.Length);
                Debug.Log(AnyBaseMutationDialogue[randomizedLine]);
                finalDialogueString = AnyBaseMutationDialogue[randomizedLine];
            }
            else if (BaseNeeded.getType() == "Haruspical")
            {
                int randomizedLine = Random.Range(0, AnyBaseHaruspicalDialogue.Length);
                Debug.Log(AnyBaseHaruspicalDialogue[randomizedLine]);
                finalDialogueString = AnyBaseHaruspicalDialogue[randomizedLine];
            }
            else if (BaseNeeded.getType() == "Emanation")
            {
                int randomizedLine = Random.Range(0, AnyBaseEmantionDialogue.Length);
                Debug.Log(AnyBaseEmantionDialogue[randomizedLine]);
                finalDialogueString = AnyBaseEmantionDialogue[randomizedLine];
            }
            else if (BaseNeeded.getType() == "Evocation")
            {
                int randomizedLine = Random.Range(0, AnyBaseEvocationDialogue.Length);
                Debug.Log(AnyBaseEvocationDialogue[randomizedLine]);
                finalDialogueString = AnyBaseEvocationDialogue[randomizedLine];
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
            Debug.Log(BaseNeeded +" and "+ MainElement);
            switch (BaseNeeded.getType())
            {
                case "Amelioration":
                    if(MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, WarSurgeDialogue.Length);
                        Debug.Log(WarSurgeDialogue[randomizedLine]);
                        finalDialogueString = WarSurgeDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, WizardsBrewDialogue.Length);
                        Debug.Log(WizardsBrewDialogue[randomizedLine]);
                        finalDialogueString = WizardsBrewDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, TouchOfWondermentDialogue.Length);
                        Debug.Log(TouchOfWondermentDialogue[randomizedLine]);
                        finalDialogueString = TouchOfWondermentDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, VerdantRejuvenationDialogue.Length);
                        Debug.Log(VerdantRejuvenationDialogue[randomizedLine]);
                        finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, AutoRepairDialogue.Length);
                        Debug.Log(AutoRepairDialogue[randomizedLine]);
                        finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, CalmOfTheDeadDialogue.Length);
                        Debug.Log(CalmOfTheDeadDialogue[randomizedLine]);
                        finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                    }
                    break;
                case "Mutation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, DragonicShellDialogue.Length);
                            Debug.Log(DragonicShellDialogue[randomizedLine]);
                            finalDialogueString = DragonicShellDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, AqeuousFromeDialogue.Length);
                            Debug.Log(AqeuousFromeDialogue[randomizedLine]);
                            finalDialogueString = AqeuousFromeDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, NarcissusBlendDialogue.Length);
                            Debug.Log(NarcissusBlendDialogue[randomizedLine]);
                            finalDialogueString = NarcissusBlendDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, FrogificationDialogue.Length);
                            Debug.Log(FrogificationDialogue[randomizedLine]);
                            finalDialogueString = FrogificationDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, FormeOfTheMarionetteDialogue.Length);
                            Debug.Log(FormeOfTheMarionetteDialogue[randomizedLine]);
                            finalDialogueString = FormeOfTheMarionetteDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, PerceptualArrayDialogue.Length);
                            Debug.Log(PerceptualArrayDialogue[randomizedLine]);
                            finalDialogueString = PerceptualArrayDialogue[randomizedLine];
                        }
                    }
                    break;
                case "Haruspical":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, DivineScryerDialogue.Length);
                            Debug.Log(DivineScryerDialogue[randomizedLine]);
                            finalDialogueString = DivineScryerDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, PotionOfPremonitionDialogue.Length);
                            Debug.Log(PotionOfPremonitionDialogue[randomizedLine]);
                            finalDialogueString = PotionOfPremonitionDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, FortuitousVisionsDialogue.Length);
                            Debug.Log(FortuitousVisionsDialogue[randomizedLine]);
                            finalDialogueString = FortuitousVisionsDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, WoodlandWhispersDialogue.Length);
                            Debug.Log(WoodlandWhispersDialogue[randomizedLine]);
                            finalDialogueString = WoodlandWhispersDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, RetraceMachinationDialogue.Length);
                            Debug.Log(RetraceMachinationDialogue[randomizedLine]);
                            finalDialogueString = RetraceMachinationDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, DeadmansTongueDialogue.Length);
                            Debug.Log(DeadmansTongueDialogue[randomizedLine]);
                            finalDialogueString = DeadmansTongueDialogue[randomizedLine];
                        }
                    }
                    break;
                case "Emanation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, HerculeanSerumDialogue.Length);
                            Debug.Log(HerculeanSerumDialogue[randomizedLine]);
                            finalDialogueString = HerculeanSerumDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, KnowledgeMeadDialogue.Length);
                            Debug.Log(KnowledgeMeadDialogue[randomizedLine]);
                            finalDialogueString = KnowledgeMeadDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0, PinchOfErosDialogue.Length);
                            Debug.Log(PinchOfErosDialogue[randomizedLine]);
                            finalDialogueString = PinchOfErosDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, DomainOfSeclusionDialogue.Length);
                            Debug.Log(DomainOfSeclusionDialogue[randomizedLine]);
                            finalDialogueString = DomainOfSeclusionDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, FeatheredStepsDialogue.Length);
                            Debug.Log(FeatheredStepsDialogue[randomizedLine]);
                            finalDialogueString = FeatheredStepsDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, GazeOfTheOutersideDialogue.Length);
                            Debug.Log(GazeOfTheOutersideDialogue[randomizedLine]);
                            finalDialogueString = GazeOfTheOutersideDialogue[randomizedLine];
                        }
                    }
                    break;
                case "Evocation":
                    {
                        if (MainElement.getName() == "Super Red")
                        {
                            int randomizedLine = Random.Range(0, SalamandersBaitDialogue.Length);
                            Debug.Log(SalamandersBaitDialogue[randomizedLine]);
                            finalDialogueString = SalamandersBaitDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Blue")
                        {
                            int randomizedLine = Random.Range(0, RusalkasCallDialogue.Length);
                            Debug.Log(RusalkasCallDialogue[randomizedLine]);
                            finalDialogueString = RusalkasCallDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Super Yellow")
                        {
                            int randomizedLine = Random.Range(0,ToadstoolEssenceDialogue.Length);
                            Debug.Log(ToadstoolEssenceDialogue[randomizedLine]);
                            finalDialogueString = ToadstoolEssenceDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Green")
                        {
                            int randomizedLine = Random.Range(0, DryadsOfferingDialogue.Length);
                            Debug.Log(DryadsOfferingDialogue[randomizedLine]);
                            finalDialogueString = DryadsOfferingDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Orange")
                        {
                            int randomizedLine = Random.Range(0, SoulInstallDialogue.Length);
                            Debug.Log(SoulInstallDialogue[randomizedLine]);
                            finalDialogueString = SoulInstallDialogue[randomizedLine];
                        }
                        if (MainElement.getName() == "Purple")
                        {
                            int randomizedLine = Random.Range(0, SolomonsBloodDialogue.Length);
                            Debug.Log(SolomonsBloodDialogue[randomizedLine]);
                            finalDialogueString = SolomonsBloodDialogue[randomizedLine];
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
        CurrentTimer -= Time.deltaTime; //currenttimer (patience) ticks down the moment it spawns
        patienceUI.fillAmount = (CurrentTimer / PatienceTimer); //circle UI for patience.

        /*
        if (CurrentTimer <= 0)//Once the patience runs out
        {
            Despawn();
            RepManager.repMaster.DecreaseRep(repReducePerCustomer);

            //update
        }
        */
        //^^^above code is shifted to LevelScript. which handles spawning and despawning of customers - applying changes to rep (or others) when appropriate
        
    }


}
