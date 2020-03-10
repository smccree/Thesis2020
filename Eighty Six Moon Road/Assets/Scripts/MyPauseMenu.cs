using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public bool canPause;
    public GameObject menu;
    public GameObject notesPanel;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    private void Awake()
    {
        //menu.SetActive(false);
        canPause = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && canPause == true)
        {
            if(isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }
    private void LateUpdate()
    {
        if (fps.canMove == true)
        {
            canPause = true; //quick fixing - after dialogue system closes won't let you pause for some reason
        }
    }

    void PauseGame()
    {
        menu.SetActive(true);
        isPaused = true;
        fps.canMove = false;
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        isPaused = false;
        fps.canMove = true;
    }

    public void ShowNotes()
    {
        //Panel with text from collected notes
        notesPanel.GetComponent<NotePanel>().ShowPanel();
        canPause = false; //can't un pause menu
    }

    public void HideNotes()
    {
        //back button script
        notesPanel.GetComponent<NotePanel>().HidePanel();
        canPause = true; //can un pause menu
    }

}
