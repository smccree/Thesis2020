using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePanel : MonoBehaviour
{
    //the panel and also UI buttons for all the notes in the game
    public GameObject panel;

    public GameObject intro;
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

    public GameObject[] notes = { note1, note2, note3, note4, note5, note6, note7, note8, note9,
        note10, note11, note12, note13, note14, note15, note16, note17, note18,
        note19, note20, note21, note22, note23, note24, note25, note26, note27};
    
    void Awake()
    {
        panel.SetActive(false);
        InitializePanel();
    }

    private void Update()
    {
        CheckForNotes();
    }
    public void ShowPanel()
    {
        Debug.Log("Showing Panel");
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }

    void InitializePanel()
    {
        intro.SetActive(true);
        foreach (GameObject note in notes)
        {
            note.SetActive(false);
        }
    }    

    void CheckForNotes()
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
