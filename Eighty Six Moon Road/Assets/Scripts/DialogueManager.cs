using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    //Dialogue box variables:
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public Animator D_animator;

    //Input Window Variables:
    public InputManager inputManager;

    //Access to FPS character controller movement script
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    //Pause Menu --> can't pause game while dialogue system is happening
    public MyPauseMenu menu;

    //building simple dialogue system to start - added complexity l8r
    //empty queue to add sentences to
    private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //set dialogue box as inactive from start
        //dialogueBox.SetActive(false);

    }
    //steps to do this:
    //1: pause player movement (enter key + keyboard type become active)
    //2: pop up dialogue box
    //3: spawn first message from Voice
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        fps.canMove = false; //pause movement
        menu.canPause = false; //can't pause
       
        //dialogueBox.SetActive(true); //just in case it's inactive and we can't use it again
        
        //temporarily disable while dialogue window is open
        inputManager.inputWindow.SetActive(false);
        D_animator.SetBool("IsOpen", true); //open dialogue box animation

        nameText.text = dialogue.name;//person's name

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //check to see if there are more sentences to show
        Debug.Log(sentences.Count);

        //adding this - not sure if it works
        /*while (sentences.Count > 0)
        {

        }*/
        if (sentences.Count == 0)
        {
            EndDialogue(); //no more sentences so close dialogue box
            return;
        }
        string sentence = sentences.Dequeue();

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

        //testing
        string test = GetPlayerInput();
        Debug.Log("test value saved: " + test);
        //this doesn't work but I'm tired. Gnite
    }
//----------------------------------------------- V2 Updates: AI System -----------------------------------------------------------------
    public string GetPlayerInput()
    {
        //(supposedly) after unloading / displaying a sentence the player should be able to respond in the input window

        return inputManager.userInput;

        

    }

    /*Incomplete: updated version of "Start Dialogue" class that takes in a keycode that corresponds to the line of dialogue
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

        //display conversation opener
        string[] dialogue_options = DialogueLines.dict_lines[key];
        string[] keywords = DialogueLines.dict_keywords[key];
        string player_input = GetPlayerInput();

        string response = ChooseResponse(keywords, dialogue_options, player_input);

    }

    /*Chooses the next line of dialogue based on the player's text input
     * chooses based on number of 'keywords' contained in the string
     * the 'key' represents which area/conversation we are on s/t we know what keywords we are looking for
     * and the acceptable responses
     * 
     * MIGHT change this to take (string[] options, string input) instead of key + input
     * MIGHT move (key, input) to AIDialogue.
     */
    public string ChooseResponse(string[] keywords, string[] dialogue_options, string input)
    {
        string current_word = "";
        string finalresponse = "";

        //initialize as 0 keys so we can increment later if a key is found.
        int num_keys = 0;

        //check whether a word in the input string matches a keyword
        foreach(char c in input)
        {
            if(char.IsWhiteSpace(c))
            {
                foreach(string thiskey in keywords)
                {
                    if(thiskey.Equals(current_word))
                    {
                        num_keys++;
                    }
                }
                current_word = "";
            }
            current_word += c;
        }

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

        //all 3 keywords found
        else if(num_keys == 3)
        {
            finalresponse = dialogue_options[4];
        }

        else
        {
            finalresponse = "Whoops! Something went wrong. Debug.";
        }
        Debug.Log("Printing final response: " + finalresponse);
        return finalresponse;
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           