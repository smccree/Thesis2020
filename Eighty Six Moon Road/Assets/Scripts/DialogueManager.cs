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
    //I do need this
    //empty queue to add sentences to
    private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //set dialogue box as inactive from start
        dialogueBox.SetActive(false);
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
        dialogueBox.SetActive(true);
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
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           