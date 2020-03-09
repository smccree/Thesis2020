using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    //Game Version: AI or Simple
    public bool useAI;
    public bool isEnd; //trigger end game scene transition

    //public string key; //set on each event trigger

    //Dialogue box variables:
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public Animator D_animator;

    //Input Window Variables:
    public InputManager inputManager;

    //Pop up Window Variable:
    public DialoguePopup popupManager;

    //Access to FPS character controller movement script
    public GameObject player;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    //Pause Menu --> can't pause game while dialogue system is happening
    public MyPauseMenu menu;

    //building simple dialogue system to start - added complexity l8r
    //empty queue to add sentences to
    private Queue<string> sentences;

    //building AI dialogue system variables:
    private string[] keywords;
    private string[] dialogue_options;
    private string key;

    //Control reminder for cancelling conversation
    public GameObject enterControls;

    //ending button - for end drama
    public GameObject endingbutton;
    public EndDramaTrigger_V2 endspawner;

    //bools to keep track of whether or not we've finished this keyword's conversation
    private bool entrance;
    private bool dining;
    private bool library;
    private bool study;
    private bool rebecca;
    private bool drawing;
    private bool fred;
    private bool eliza;
    private bool dressing;
    private bool kitchen;
    private bool house;
    private bool cellar;

    void Start()
    {
        sentences = new Queue<string>();
        //useAI = true;
        isEnd = false;
        endingbutton.SetActive(false);
        useAI = false;

        entrance = false;
        dining = false;
        library = false;
        study = false;
        rebecca = false;
        drawing = false;
        fred = false;
        eliza = false;
        dressing = false;
        kitchen = false;
        house = false;
        cellar = false;
    }
    //steps to do this:
    //1: pause player movement (enter key + keyboard type become active)
    //2: pop up dialogue box
    //3: spawn first message from Voice
    public void StartDialogue(Dialogue dialogue)
    {
        //----------------------------------Separating Simple Dialogue system vs. AI based one -------------------------------------------------

        Debug.Log("Starting AI Dialogue");

        //clear any dialogue pop ups on screen
        popupManager.popupDialogueBox.SetActive(false);

        key = player.GetComponent<EventTriggerControl>().eventTrigger.GetComponent<TriggerProperties>().trigger_keyword;
        Debug.Log("this is the keyword: " + key);
        AIDialogue(key);
        
        /*
        Debug.Log("Starting Simple Dialogue");
        fps.canMove = false; //pause movement
        menu.canPause = false; //can't pause

        dialogueBox.SetActive(true); //just in case it's inactive and we can't use it again

        //temporarily disable while dialogue window is open
        inputManager.inputWindow.SetActive(false);
        D_animator.SetBool("IsOpen", true); //open dialogue box animation

        nameText.text = dialogue.name;//person's name

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log("Start Dialogue sentences: " + sentences.Count);
        DisplayNextSentence();
        */    
    }

    public void DisplayNextSentence()
    {
        //check to see if there are more sentences to show
        Debug.Log("Display Next Sentence sentences: " + sentences.Count);

        if (sentences.Count == 0)
        {
            EndDialogue(); //no more sentences so close dialogue box
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log("Num sentences after dequeue: " + sentences.Count);
        StopAllCoroutines();

        //type letters 1 by 1 on screen
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);//show the sentence
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        //make dialogue box lower and disappear
        //also need to un-freeze player motion
        Debug.Log("end of conversation");

        D_animator.SetBool("IsOpen", false);

        //open input window
        inputManager.inputWindow.SetActive(true);
        inputManager.OpenInputWindow();
        fps.isLock = false;

        //disable dialoguebox for button controls
        dialogueBox.SetActive(false);
        fps.canMove = false;
    }

    public void Unfreeze() //separate this into a method for testing reasons
    {
        fps.canMove = true;
        fps.isLock = true; //hide cursor now that dialogue stuff is done
        menu.canPause = true; //game can pause again

        //comment if bugged
        dialogueBox.SetActive(true);
        D_animator.SetBool("IsOpen", false);
    }
//----------------------------------------------- V2 Updates: AI System -----------------------------------------------------------------

    /*Updated version of "Start Dialogue" class that takes in a keycode that corresponds to the line of dialogue
        that should be read into the method from the DialogueLines class*/
    public void AIDialogue(string key)
    {
        fps.canMove = false; //pause movement
        menu.canPause = false; //can't pause

        //temporarily disable while dialogue window is open
        inputManager.inputWindow.SetActive(false);
        D_animator.SetBool("IsOpen", true); //open dialogue box animation

        if( key == "entrance")
        {
            nameText.text = DialogueLines.Name;//person's name
        }
        else
        {
            nameText.text = DialogueLines.Name_Revealed;
        }
        
        //get the dialogue options and keywords for this room trigger
        dialogue_options = DialogueLines.dict_lines[key];
        keywords = DialogueLines.dict_keywords[key];

        //Display opening line
        dialogueText.text = dialogue_options[0];
    }

    /*Chooses the next line of dialogue based on the player's text input
     * chooses based on number of 'keywords' contained in the string
     * the 'key' represents which area/conversation we are on s/t we know what keywords we are looking for
     * and the acceptable responses
     * 
     */
    public string ChooseResponse(string[] keywords, string[] dialogue_options, string input)
    {
        string current_word = "";
        string finalresponse = "";

        //initialize as 0 keys so we can increment later if a key is found.
        //add to num_chars each time you've indexed through
        int num_keys = 0;
        int end = input.Length - 1;

        //check whether a word in the input string matches a keyword
        foreach(char c in input)
        {
            if (char.IsWhiteSpace(c) || c.Equals(",") || c.Equals("!") || c.Equals(".") || c.Equals("?"))
            {
                num_keys += CompareToKeys(current_word, keywords);

                current_word = "";
                //skip white space character?
                continue;
            }
            current_word += c;
        }
        num_keys += CompareToKeys(current_word, keywords);

        //time to choose the response
        if(!useAI)
        {
            finalresponse = dialogue_options[2];
        }

        else
        {
            //0 keywords found - placeholder: chooses a random line from a set of 5 agitated responses.
            if (num_keys == 0)
            {
                finalresponse = dialogue_options[1];
            }

            //only 1 keyword found
            else if (num_keys == 1)
            {
                finalresponse = dialogue_options[2];
            }

            //only 2 keywords found
            else if (num_keys == 2)
            {
                finalresponse = dialogue_options[3];
            }

            //3+ keywords found (accounts for multiple instances of the same word in a phrase).
            else if (num_keys >= 3)
            {
                finalresponse = dialogue_options[4];
            }

            else
            {
                finalresponse = "Whoops! Something went wrong. Debug.";
            }
        }
        
        return finalresponse;
    }

    public void ShowResponse(string player_input)
    {
        //Generate response from AI to show player
        string response = ChooseResponse(keywords, dialogue_options, player_input);

        //Display AI response as pop-up 
        popupManager.DictionaryPopup(DialogueLines.Name_Revealed, response);
        if(key == "ending")
        {
            isEnd = true; //fancy fade to black stuff
        }
        else
        {
            SetConversationStatus();
            Unfreeze();
        }
    }

    int CompareToKeys(string word, string[] keywords)
    {
        foreach (string thiskey in keywords)
        {
            if (thiskey.Equals(word))
            {
                return 1; //return and terminate search
            }
        }
        return 0; //found nothing so return 0
    }

    public void CancelDialogue()
    {
        //Close input window: let players re-read things before answering prompt

        //cancel response:
        int randomchoice = Random.Range(0, 3);

        string cancel = null;

        if(randomchoice == 0)
        {
            cancel = DialogueLines.Voice_Cancel_1;
        }

        else if (randomchoice == 1)
        {
            cancel = DialogueLines.Voice_Cancel_2;
        }

        else if (randomchoice == 2)
        {
            cancel = DialogueLines.Voice_Cancel_3;
        }

        //Display AI response as pop-up 
        popupManager.DictionaryPopup(DialogueLines.Name_Revealed, cancel);
        enterControls.GetComponent<ControlManager>().ShowControls();
        Unfreeze();
    }

    public void EndingDialogue(string[] options, string[] keywords)
    {
        nameText.text = DialogueLines.Name_Revealed;//person's name

        sentences.Clear();
        foreach (string sentence in options)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log("Start Dialogue sentences: " + sentences.Count);
        EndingDisplayNextSentence();
    }

    public void EndingDisplayNextSentence()
    {
        //check to see if there are more sentences to show
        Debug.Log("Display Next Sentence sentences: " + sentences.Count);

        if (sentences.Count == 0)
        {
            EndingPopup(); //no more sentences so close dialogue box
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log("Num sentences after dequeue: " + sentences.Count);
        StopAllCoroutines();

        //type letters 1 by 1 on screen
        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);//show the sentence
    }

    public void EndingPopup()
    {
        //Display AI response as pop-up 
        popupManager.DictionaryPopup(DialogueLines.Name, DialogueLines.Voice_EndDrama_10);
        isEnd = true; //fancy fade to black stuff
    }

    public void SetConversationStatus()
    {
        //inefficient, but band-aid solution. Works because there are only 12 triggers/booleans, but for a larger game this would be terrible.
        if(key == "entrance")
        {
            if (entrance == false)
            {
                endspawner.num_triggered++;
                entrance = true;

            }
        }
        else if(key == "dining")
        {
            if (dining == false)
            {
                endspawner.num_triggered++;
                dining = true;

            }
        }
        else if (key == "library")
        {
            if (library == false)
            {
                endspawner.num_triggered++;
                library = true;

            }
        }
        else if(key == "study")
        {
            if (study == false)
            {
                endspawner.num_triggered++;
                study = true;

            }
        }
        else if(key == "drawing")
        {
            if (drawing == false)
            {
                endspawner.num_triggered++;
                drawing = true;

            }
        }
        else if (key == "rebecca")
        {
            if (rebecca == false)
            {
                endspawner.num_triggered++;
                rebecca = true;

            }
        }
        else if (key == "eliza")
        {
            if (eliza == false)
            {
                endspawner.num_triggered++;
                eliza = true;

            }
        }
        else if (key == "dressing")
        {
            if (dressing == false)
            {
                endspawner.num_triggered++;
                dressing = true;

            }
        }
        else if (key == "fred")
        {
            if (fred == false)
            {
                endspawner.num_triggered++;
                fred = true;

            }
        }
        else if (key == "cellar")
        {
            if (cellar == false)
            {
                endspawner.num_triggered++;
                cellar = true;

            }
        }
        else if (key == "kitchen")
        {
            if (kitchen == false)
            {
                endspawner.num_triggered++;
                kitchen = true;
                
            }
        }
        else if (key == "housekeeper")
        {
            if(house == false)
            {
                endspawner.num_triggered++;
                house = true;  
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           