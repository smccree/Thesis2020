using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    //Game Version: AI or Simple
    public bool useAI;
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

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        useAI = true;
        //useAI = false;
        //DialogueLines.Initialize();

    }
    //steps to do this:
    //1: pause player movement (enter key + keyboard type become active)
    //2: pop up dialogue box
    //3: spawn first message from Voice
    public void StartDialogue(Dialogue dialogue)
    {
        //----------------------------------Separating Simple Dialogue system vs. AI based one -------------------------------------------------

        if (useAI)
        {
            Debug.Log("Starting AI Dialogue");
            string key = player.GetComponent<EventTriggerControl>().eventTrigger.GetComponent<TriggerProperties>().trigger_keyword;
            Debug.Log("this is the keyword: " + key);
            AIDialogue(key);
        }
        else
        {
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
        }      
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
        Debug.Log("Starting AI conversation");

        fps.canMove = false; //pause movement
        menu.canPause = false; //can't pause

        //temporarily disable while dialogue window is open
        inputManager.inputWindow.SetActive(false);
        D_animator.SetBool("IsOpen", true); //open dialogue box animation

        nameText.text = DialogueLines.Name;//person's name

        //Initialize Key-Value Dictionary Pairs
        //DialogueLines.Initialize();

        //get the dialogue options and keywords for this room trigger
        dialogue_options = DialogueLines.dict_lines[key];
        keywords = DialogueLines.dict_keywords[key];

        //Display opening line
        dialogueText.text = dialogue_options[0];
        Debug.Log(dialogueText.text);
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
        //0 keywords found - placeholder: chooses a random line from a set of 5 agitated responses.
        if (num_keys == 0)
        {
            int randomchoice = Random.Range(0, 4);

            if(randomchoice == 0)
            {
                finalresponse = DialogueLines.Voice_Failure_1;
            }
            else if(randomchoice == 1)
            {
                finalresponse = DialogueLines.Voice_Failure_2;
            }
            else if(randomchoice == 2)
            {
                finalresponse = DialogueLines.Voice_Failure_3;
            }
            else if(randomchoice == 3)
            {
                finalresponse = DialogueLines.Voice_Failure_4;
            }
            else
            {
                finalresponse = DialogueLines.Voice_Failure_5;
            }
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

        //all 3 keywords found (accounts for multiple instances of the same word in a phrase).
        else if(num_keys >= 3)
        {
            finalresponse = dialogue_options[4];
        }

        else
        {
            finalresponse = "Whoops! Something went wrong. Debug.";
        }
        return finalresponse;
    }

    public void ShowResponse(string player_input)
    {
        //Generate response from AI to show player
        string response = ChooseResponse(keywords, dialogue_options, player_input);
        Debug.Log(response);

        //Display AI response as pop-up 
        popupManager.DictionaryPopup(DialogueLines.Name, response);
        //player.GetComponent<EventTriggerControl>().eventTrigger.GetComponent<TriggerProperties>().interacted = true;
        Unfreeze();
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
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           