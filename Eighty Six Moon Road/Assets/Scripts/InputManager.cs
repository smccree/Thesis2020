using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    //Input Window Variables:
    public GameObject inputWindow;
    public TMP_InputField inputText;
    public Animator I_animator;
    public string userInput = null;

    public DialogueManager dialogueBox;

    //am I using the AI system?
    //these are inherited from AIOpenWindow() method.
    public bool useAI;

    private void Start()
    {
        useAI = true;
        //useAI = false;
    }
    public void ReceiveInput()
    {
        //function to receive input from the text input window
        //save characters as player dialogue line

        string playerText = inputText.text;

        userInput = playerText;
        inputText.text = null;

        Debug.Log(userInput);
        if(useAI)
        {
            CloseInputWindow();
            dialogueBox.ShowResponse(userInput);
        }
        else
        {
            CloseInputWindow();
            dialogueBox.Unfreeze();
        }
        
    }

    public void CloseInputWindow()
    {
        I_animator.SetBool("IsOpen", false); //need set active = false to stop it from reading keyboard button presses
        inputWindow.SetActive(false);
    }

    public void OpenInputWindow()
    {
        Debug.Log("Opening Input Window");
        inputWindow.SetActive(true);
        I_animator.SetBool("IsOpen", true);
    }
}
