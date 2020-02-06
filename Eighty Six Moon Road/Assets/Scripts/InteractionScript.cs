using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionScript : MonoBehaviour
{
    //class handles button click interactions and object interactions

    //initializing keycode variable for button click
    public KeyCode click;

    //the button we're trying to click
    private Button button;

    void Awake()
    {
        //get the current button or interactable obj. --> assign to variable on initialization
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(click)) //if I'm pressing the right key, then invoke on click functionality
        {
            button.onClick.Invoke();
        }
    }
}
