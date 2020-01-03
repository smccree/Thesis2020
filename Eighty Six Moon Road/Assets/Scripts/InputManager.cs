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
    private string userInput;

    //Access to FPS character controller movement script
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    public void Activate()
    {
        //start up script for input window functionality
        Debug.Log("Opening Input Window");
        OpenInputWindow();
        

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

    private void CloseInputWindow()
    {
        I_animator.SetBool("IsOpen", false);
        //fps.canMove = true;
    }

    private void OpenInputWindow()
    {
        I_animator.SetBool("IsOpen", true);
        //fps.canMove = false;
    }
}
