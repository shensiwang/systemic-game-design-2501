using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The_Customer : MonoBehaviour
{
    public string Faction = "";
    public string WinningFaction; //Once the Faction script is ready, take the winning faction
    public Faction factionInfo;

    public string Event = "Normal";// Once Event script is done, take current event name
    public EventMaster eventMasterRef; 

    public BaseInterface BaseNeeded;
    public ElementInterface FirstElement;
    public ElementInterface MainElement;
    public ElementInterface SecondElement;

    public string finalDialogueString; //added to access this variable and display it
    public List<string> CustomerScript; //The final script of the customer;
    [Header("-----------Event Dialogue--------------")]
    [TextArea(5, 5)]
    public string[] NormalEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Win_FireOutbreakEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Lose_FireOutbreakEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Win_FireOutbreakEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Lose_FireOutbreakEventDialogue;

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
        int BaseRandomizer;
        int ElementRandomizer1;
        int ElementRandomizer2;

        int EventSpecificPotionRandomizer;
        int EventDialogueRandomizer;

        factionInfo = FindObjectOfType<Faction>();
        WinningFaction = factionInfo.winningFaction; //get winning faction

        eventMasterRef = GameObject.Find("LevelInformation").GetComponent<EventMaster>(); // get random event type from EventMaster

        switch (eventMasterRef.GetEvent())
        {
            case "Normal":
                EventDialogueRandomizer = Random.Range(0, NormalEventDialogue.Length);
                CustomerScript.Add(NormalEventDialogue[EventDialogueRandomizer]);

                BaseRandomizer = Random.Range(0, 5);
                ElementRandomizer1 = Random.Range(0, 3);
                ElementRandomizer2 = Random.Range(0, 3);

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
               

                break;
            case "Fire":
                if(WinningFaction=="A")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Win_FireOutbreakEventDialogue.Length);
                        CustomerScript.Add(A_Win_FireOutbreakEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if(EventSpecificPotionRandomizer==0) //Draconic Shell
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else if(EventSpecificPotionRandomizer == 1)//Salamander Bait
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                        }
                        else
                        {
                            BaseNeeded = new Amelioration();//Touch Of Wonderment
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                        }
                      
                    }
                    else if(Faction=="B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Lose_FireOutbreakEventDialogue.Length);
                        CustomerScript.Add(B_Lose_FireOutbreakEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0)//Verdant Rejuvination
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Auto-Repair
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                        }
                        else
                        {
                            BaseNeeded = new Haruspical(); //Deadman's Tongue
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                        }
                    }
                    else
                    {
                        Debug.Log("HAHA");
                    }
                }
                else if (WinningFaction=="B")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Lose_FireOutbreakEventDialogue.Length);
                        CustomerScript.Add(A_Lose_FireOutbreakEventDialogue[EventDialogueRandomizer]);
                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Salamander's Bait
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Wizard's Brew
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                        }
                        else
                        {
                            BaseNeeded = new Emanation();//War Surge
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                        }
                    }
                    else if (Faction == "B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Win_FireOutbreakEventDialogue.Length);
                        CustomerScript.Add(B_Win_FireOutbreakEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);
                        if (EventSpecificPotionRandomizer == 0)//Fortuitous Visions
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                        }
                        else if (EventSpecificPotionRandomizer == 1) // Perceptual Array
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                        }
                        else
                        {
                            BaseNeeded = new Haruspical();//Potion of Premonition
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                        }
                    }
                    else
                    {
                        Debug.Log("HAHA");
                    }
                }
                else
                {
                    Debug.Log("Nothing is here you stupid idiot!");
                }
                break;

        }

        //Determines Final Sentence
        switch (BaseNeeded.getType())
        {
            case "Amelioration":
                if (MainElement.getName() == "Super Red")
                {
                    int randomizedLine = Random.Range(0, WarSurgeDialogue.Length);
                    finalDialogueString = WarSurgeDialogue[randomizedLine];
                }
                if (MainElement.getName() == "Super Blue")
                {
                    int randomizedLine = Random.Range(0, WizardsBrewDialogue.Length);
                    finalDialogueString = WizardsBrewDialogue[randomizedLine];
                }
                if (MainElement.getName() == "Super Yellow")
                {
                    int randomizedLine = Random.Range(0, TouchOfWondermentDialogue.Length);
                    finalDialogueString = TouchOfWondermentDialogue[randomizedLine];
                }
                if (MainElement.getName() == "Green")
                {
                    int randomizedLine = Random.Range(0, VerdantRejuvenationDialogue.Length);
                    finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                }
                if (MainElement.getName() == "Orange")
                {
                    int randomizedLine = Random.Range(0, AutoRepairDialogue.Length);
                    finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                }
                if (MainElement.getName() == "Purple")
                {
                    int randomizedLine = Random.Range(0, CalmOfTheDeadDialogue.Length);
                    finalDialogueString = VerdantRejuvenationDialogue[randomizedLine];
                }
                break;
            case "Mutation":
                {
                    if (MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, DragonicShellDialogue.Length);
                        finalDialogueString = DragonicShellDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, AqeuousFromeDialogue.Length);
                        finalDialogueString = AqeuousFromeDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, NarcissusBlendDialogue.Length);
                        finalDialogueString = NarcissusBlendDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, FrogificationDialogue.Length);
                        finalDialogueString = FrogificationDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, FormeOfTheMarionetteDialogue.Length);
                        finalDialogueString = FormeOfTheMarionetteDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, PerceptualArrayDialogue.Length);
                        finalDialogueString = PerceptualArrayDialogue[randomizedLine];
                    }
                }
                break;
            case "Haruspical":
                {
                    if (MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, DivineScryerDialogue.Length);
                        finalDialogueString = DivineScryerDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, PotionOfPremonitionDialogue.Length);
                        finalDialogueString = PotionOfPremonitionDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, FortuitousVisionsDialogue.Length);
                        finalDialogueString = FortuitousVisionsDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, WoodlandWhispersDialogue.Length);
                        finalDialogueString = WoodlandWhispersDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, RetraceMachinationDialogue.Length);
                        finalDialogueString = RetraceMachinationDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, DeadmansTongueDialogue.Length);
                        finalDialogueString = DeadmansTongueDialogue[randomizedLine];
                    }
                }
                break;
            case "Emanation":
                {
                    if (MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, HerculeanSerumDialogue.Length);
                        finalDialogueString = HerculeanSerumDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, KnowledgeMeadDialogue.Length);
                        finalDialogueString = KnowledgeMeadDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, PinchOfErosDialogue.Length);
                        finalDialogueString = PinchOfErosDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, DomainOfSeclusionDialogue.Length);
                        finalDialogueString = DomainOfSeclusionDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, FeatheredStepsDialogue.Length);
                        finalDialogueString = FeatheredStepsDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, GazeOfTheOutersideDialogue.Length);
                        finalDialogueString = GazeOfTheOutersideDialogue[randomizedLine];
                    }
                }
                break;
            case "Evocation":
                {
                    if (MainElement.getName() == "Super Red")
                    {
                        int randomizedLine = Random.Range(0, SalamandersBaitDialogue.Length);
                        finalDialogueString = SalamandersBaitDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Blue")
                    {
                        int randomizedLine = Random.Range(0, RusalkasCallDialogue.Length);
                        finalDialogueString = RusalkasCallDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Super Yellow")
                    {
                        int randomizedLine = Random.Range(0, ToadstoolEssenceDialogue.Length);
                        finalDialogueString = ToadstoolEssenceDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Green")
                    {
                        int randomizedLine = Random.Range(0, DryadsOfferingDialogue.Length);
                        finalDialogueString = DryadsOfferingDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Orange")
                    {
                        int randomizedLine = Random.Range(0, SoulInstallDialogue.Length);
                        finalDialogueString = SoulInstallDialogue[randomizedLine];
                    }
                    if (MainElement.getName() == "Purple")
                    {
                        int randomizedLine = Random.Range(0, SolomonsBloodDialogue.Length);
                        finalDialogueString = SolomonsBloodDialogue[randomizedLine];
                    }
                }
                break;
        }
        Debug.Log("This customer wants a " + MainElement.PotionName(BaseNeeded));
        CustomerScript.Add(finalDialogueString);
        Debug.Log(CustomerScript[0] + "\n" + CustomerScript[1]);
  

    }
}
