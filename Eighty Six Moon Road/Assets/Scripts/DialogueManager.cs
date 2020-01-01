using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public FreezePlayer freezescript;

    //building simple dialogue system to start - added complexity l8r
    //I do need this
    //empty queue to add sentences to
    private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }
    //steps to do this:
    //1: pause player movement (enter key + keyboard type become active)
    //2: pop up dialogue box
    //3: spawn first message from Voice
    public void DialoguePopup()
    {
        //open up the dialogue box - triggered at specific game moments
        //freeze movement and enable text controls
        dialogueBox.SetActive(true);
        freezescript.Freeze();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        DialoguePopup();
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
        if (sentences.Count == 0)
        {
            EndDialogue(); //no more sentences so close dialogue box
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);//show the sentence

        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        //make dialogue box lower and disappear
        //also need to un-freeze player motion
        Debug.Log("end of conversation");
        dialogueBox.SetActive(false);
        freezescript.Unfreeze();
    }
}
