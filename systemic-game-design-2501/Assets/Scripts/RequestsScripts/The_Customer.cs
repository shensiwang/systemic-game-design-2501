using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The_Customer : MonoBehaviour
{
    public string Faction = "";
    public string oppFaction = "";
    public string WinningFaction; //Once the Faction script is ready, take the winning faction
    public Faction factionInfo;
    public AudioClip[] Rabbles;
    public bool willPay = true;
    public float percentagePaid = 100f;

    public string Event = "Normal";
    public EventMaster eventMasterRef;
    public LevelScript levelScriptRef;

    [Header("UI")]
    public Image timerUI; //temp use, can be changed

    public BaseInterface BaseNeeded;
    public ElementInterface FirstElement;
    public ElementInterface MainElement;
    public ElementInterface SecondElement;

    //Display the correct Faction Sprite
    public Sprite audreyMember;
    public Sprite betramMember;

    public string finalDialogueString; //added to access this variable and display it
    public List<string> CustomerScript; //The final script of the customer;
    private AudioSource CurrentRabble;
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

    [TextArea(5, 5)]
    public string[] HolidayEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Win_ThreatsOfPoisonEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Lose_ThreatsOfPoisonEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Win_ThreatsOfPoisonEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Lose_ThreatsOfPoisonEventDialogue;

    [TextArea(5, 5)]
    public string[] DivineFavorEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Win_SecretPlanEventDialogue;

    [TextArea(5, 5)]
    public string[] A_Lose_SecretPlanEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Win_SecretPlanEventDialogue;

    [TextArea(5, 5)]
    public string[] B_Lose_SecretPlanEventDialogue;

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
        int rabbleRandomizer = Random.Range(0, Rabbles.Length);
        CurrentRabble = GetComponent<AudioSource>();
        CurrentRabble.clip = Rabbles[rabbleRandomizer];
        CurrentRabble.Play();
        int BaseRandomizer;
        int ElementRandomizer1;
        int ElementRandomizer2;

        int EventSpecificPotionRandomizer;
        int EventDialogueRandomizer;

        factionInfo = FindObjectOfType<Faction>();
        levelScriptRef = FindObjectOfType<LevelScript>();
        WinningFaction = factionInfo.winningFaction; //get winning faction

        if (Faction == "A") oppFaction = "B"; //track opposing faction. use for changing loyalty in levelscript.
        else oppFaction = "A";

        //New Stuff
        DisplayFactionMember();

        CheckPayPercentage();
        CheckIfPay();

        eventMasterRef = GameObject.Find("LevelInformation").GetComponent<EventMaster>(); // get random event type from EventMaster

        switch (eventMasterRef.GetEventString())
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

                        if (EventSpecificPotionRandomizer == 0) //Auto-Repair
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Wizard's Brew
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                        }
                        else//Aqueous Frome
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
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
                        else if (EventSpecificPotionRandomizer == 1) //Salamander Bait
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                        }
                        else
                        {
                            BaseNeeded = new Emanation();//Feathered Steps
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
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

            case "Holiday":

                EventDialogueRandomizer = Random.Range(0, HolidayEventDialogue.Length);
                CustomerScript.Add(HolidayEventDialogue[EventDialogueRandomizer]);

                EventSpecificPotionRandomizer = Random.Range(0, 2);

                if (EventSpecificPotionRandomizer == 0) //ToadStool Essesnce
                {
                    BaseNeeded = new Evocation();
                    MainElement = new Yellow();
                    FirstElement = MainElement;
                    MainElement = MainElement.AddedWithYellow();
                    SecondElement = new Yellow();
                    Debug.Log(MainElement);
                }
                else if (EventSpecificPotionRandomizer == 1)//Rusalka Call
                {
                    BaseNeeded = new Evocation();
                    MainElement = new Blue();
                    FirstElement = MainElement;
                    MainElement = MainElement.AddedWithBlue();
                    SecondElement = new Blue();
                }
                else
                {
                    BaseNeeded = new Amelioration();//Touch Of Wonderment
                    MainElement = new Yellow();
                    FirstElement = MainElement;
                    MainElement = MainElement.AddedWithYellow();
                    SecondElement = new Yellow();
                }
                break;

            case "Poison":
                if (WinningFaction == "A")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Win_ThreatsOfPoisonEventDialogue.Length);
                        CustomerScript.Add(A_Win_ThreatsOfPoisonEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Gaze of the Outerside
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Frogification
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Amelioration();//War Surge
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }

                    }
                    else if (Faction == "B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Lose_ThreatsOfPoisonEventDialogue.Length);
                        CustomerScript.Add(B_Lose_ThreatsOfPoisonEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0)//Retrace Machination
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Premonition
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);

                        }
                        else//Perceptual Array
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                    }
                    else
                    {
                        Debug.Log("HAHA");
                    }
                }
                else if (WinningFaction == "B")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Lose_ThreatsOfPoisonEventDialogue.Length);
                        CustomerScript.Add(A_Lose_ThreatsOfPoisonEventDialogue[EventDialogueRandomizer]);
                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Verdant Rejuv
                        {
                            BaseNeeded = new Amelioration(); 
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Rusalka
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Haruspical();//Divine Scryer
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                    }
                    else if (Faction == "B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Win_ThreatsOfPoisonEventDialogue.Length);
                        CustomerScript.Add(B_Win_ThreatsOfPoisonEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0)// Solomon Blood
                        {
                            BaseNeeded = new Evocation();//War Surge
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1) // Marionette
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
                        }
                        else // Outerside
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
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

            case "Favor":
                if (WinningFaction == "B")
                {
                    if (Faction == "A")
                    {
                        Debug.Log("Favor for Audrey");
                        EventDialogueRandomizer = 0;
                        CustomerScript.Add(DivineFavorEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Divine Scryer
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Herculem
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Amelioration();//Touch Of Wonderment
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
                        }
                        break;

                    }
                    else if (Faction == "B")
                    {

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
                    }
                    else
                    {
                        Debug.Log("HAHA");
                    }
                }
                else if (WinningFaction == "A")
                {
                    if (Faction == "A")
                    {
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
                    }
                    else if (Faction == "B")
                    {
                        Debug.Log("Favor for Betram");
                        EventDialogueRandomizer = 1;
                        CustomerScript.Add(DivineFavorEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0)// Fortutious Vision
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1) // Wizard Brew
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else // Outerside
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
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
            case "Secret":
                if (WinningFaction == "A")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Win_SecretPlanEventDialogue.Length);
                        CustomerScript.Add(A_Win_SecretPlanEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Herculean
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Wizard
                        {
                            BaseNeeded = new Amelioration();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Amelioration();//Potion of Premonition
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        break;

                    }
                    else if (Faction == "B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Lose_SecretPlanEventDialogue.Length);
                        CustomerScript.Add(B_Lose_SecretPlanEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Soul Intsall
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Woodland Wisphers
                        {
                            BaseNeeded = new Haruspical();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Mutation();//Perceptual Array
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                    }
                }
                else if (WinningFaction == "B")
                {
                    if (Faction == "A")
                    {
                        EventDialogueRandomizer = Random.Range(0, A_Lose_SecretPlanEventDialogue.Length);
                        CustomerScript.Add(A_Lose_SecretPlanEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0) //Soul Intsall
                        {
                            BaseNeeded = new Evocation();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithRed();
                            SecondElement = new Red();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1)//Domain 
                        {
                            BaseNeeded = new Emanation();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else
                        {
                            BaseNeeded = new Mutation();//Premonition
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                    }
                    else if (Faction == "B")
                    {
                        EventDialogueRandomizer = Random.Range(0, B_Win_SecretPlanEventDialogue.Length);
                        CustomerScript.Add(B_Win_SecretPlanEventDialogue[EventDialogueRandomizer]);

                        EventSpecificPotionRandomizer = Random.Range(0, 2);

                        if (EventSpecificPotionRandomizer == 0)//Perceptual Array
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Red();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithBlue();
                            SecondElement = new Blue();
                            Debug.Log(MainElement);
                        }
                        else if (EventSpecificPotionRandomizer == 1) // Narcisius
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Yellow();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
                        }
                        else // Dryad
                        {
                            BaseNeeded = new Mutation();
                            MainElement = new Blue();
                            FirstElement = MainElement;
                            MainElement = MainElement.AddedWithYellow();
                            SecondElement = new Yellow();
                            Debug.Log(MainElement);
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

    private void Update()
    {
        timerUI.fillAmount = levelScriptRef.currentCustomerInterval / levelScriptRef.customerInterval; //update timer UI
    }

    public void CheckIfPay() //check if customer will pay, based of faction chance of pay.
    {
        float r = Random.Range(0, 100);

        if (Faction == "A")
        {
            if (factionInfo.factionAchanceOfPay == 100)
            {
                willPay = true;
            }
            else
            {
                if (r <= factionInfo.factionAchanceOfPay) //0-70, 70% chance
                {
                    willPay = true;
                }
            }
        }
        else
        {
            if (factionInfo.factionBchanceOfPay == 100)
            {
                willPay = true;
            }
            else
            {
                if (r <= factionInfo.factionBchanceOfPay) //0-70, 70% chance
                {
                    willPay = true;
                }
            }
        }
    }

    public void CheckPayPercentage()
    {
        if (Faction == "A")
        {
            percentagePaid = factionInfo.factionAPercentagePay / 100f;
        }
        else
        {
            percentagePaid = factionInfo.factionBPercentagePay / 100f;
        }
    }

    public void DisplayFactionMember()
    {
        if(Faction == "A")
        {
            this.gameObject.GetComponent<Image>().sprite = audreyMember;
        }

        else
        {
            this.gameObject.GetComponent<Image>().sprite = betramMember;
        }
    }
    
}
