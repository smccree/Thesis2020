﻿using System.Collections;
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
    public PlayerMovement freezescript;
    public Animator D_animator;

    //Input Window Variables:
    public GameObject inputWindow;
    public TMP_InputField inputText;
    public Animator I_animator;
    private string userInput;

    //building simple dialogue system to start - added complexity l8r
    //I do need this
    //empty queue to add sentences to
    private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        //dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }
    //steps to do this:
    //1: pause player movement (enter key + keyboard type become active)
    //2: pop up dialogue box
    //3: spawn first message from Voice
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        freezescript.isFrozen = true;
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
        freezescript.isFrozen = false;

        //add logic here to spawn input window maybe
        // OpenInputWindow();
    }

    public void ReceiveInput()
    {
        //function to receive input from the text input window
        //save characters as player dialogue line

        string playerText = inputText.text;
        Debug.Log(playerText); //testing

        userInput = playerText;
        Debug.Log(userInput);

        CloseInputWindow();
    }

    public void CloseInputWindow()
    {
        I_animator.SetBool("IsOpen", false);
        freezescript.isFrozen = false;
    }
    public void OpenInputWindow()
    {
        I_animator.SetBool("IsOpen", true);
        freezescript.isFrozen = true;
    }
}
