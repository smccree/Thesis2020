using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePanel : MonoBehaviour
{
    //the panel and also UI buttons for all the notes in the game
    public GameObject panel_main;
    public GameObject panel_ground;
    public GameObject panel_first;
    public GameObject panel_second;
    public GameObject panel_basement;

    public static GameObject intro;
    public static GameObject note1;
    public static GameObject note2;
    public static GameObject note3;
    public static GameObject note4;
    public static GameObject note5;
    public static GameObject note6;
    public static GameObject note7;
    public static GameObject note8;
    public static GameObject note9;
    public static GameObject note10;
    public static GameObject note11;
    public static GameObject note12;
    public static GameObject note13;
    public static GameObject note14;
    public static GameObject note15;
    public static GameObject note16;
    public static GameObject note17;
    public static GameObject note18;
    public static GameObject note19;
    public static GameObject note20;
    public static GameObject note21;
    public static GameObject note22;
    public static GameObject note23;
    public static GameObject note24;
    public static GameObject note25;
    public static GameObject note26;
    public static GameObject note27;

    public GameObject[] notes_ground = { intro, note1, note2, note3, note4, note5, note6, note7 };
    public GameObject[] notes_first = { note8, note9, note10, note11, note12, note13 };
    public GameObject[] notes_second = { note14, note15, note16, note17, note18, note19 };
    public GameObject[] notes_basement = { note20, note21, note22, note23, note24, note25, note26, note27 };
    /*void Awake()
    {
        panel_main.SetActive(false);
        panel_ground.SetActive(false);
        panel_first.SetActive(false);
        panel_second.SetActive(false);
        panel_basement.SetActive(false);

        InitializePanel(notes_ground);
        InitializePanel(notes_first);
        InitializePanel(notes_second);
        InitializePanel(notes_basement);
    }*/

    private void Update()
    {
        CheckForNotes(notes_ground);
        CheckForNotes(notes_first);
        CheckForNotes(notes_second);
        CheckForNotes(notes_basement);
    }
    public void ShowPanel()
    {
        Debug.Log("Showing Panel Main");
        panel_main.SetActive(true);
    }
    public void HidePanel()
    {
        panel_main.SetActive(false);
    }

    public void ShowPanelGround()
    {
        Debug.Log("Showing Panel Ground");
        panel_ground.SetActive(true);
    }
    public void HidePanelGround()
    {
        panel_ground.SetActive(false);
    }

    public void ShowPanelFirst()
    {
        Debug.Log("Showing Panel First");
        panel_first.SetActive(true);
    }
    public void HidePanelFirst()
    {
        panel_first.SetActive(false);
    }
    public void ShowPanelSecond()
    {
        Debug.Log("Showing Panel Second");
        panel_second.SetActive(true);
    }
    public void HidePanelSecond()
    {
        panel_second.SetActive(false);
    }
    public void ShowPanelBasement()
    {
        Debug.Log("Showing Basement Panel");
        panel_basement.SetActive(true);
    }
    public void HidePanelBasement()
    {
        panel_basement.SetActive(false);
    }

    void InitializePanel(GameObject[] notes)
    {
        foreach (GameObject note in notes)
        {
            if(note.name == "IntroButton")
            {
                note.SetActive(true);
            }
            else
            {
                note.SetActive(false);
            }
        }
    }

    void CheckForNotes(GameObject[] notes)
    {
        foreach (GameObject note in notes)
        {
            if(note.GetComponent<LoreObjectButton>().interacted == true) 
            {
                
                note.SetActive(true);
            }
        }
    }
}
