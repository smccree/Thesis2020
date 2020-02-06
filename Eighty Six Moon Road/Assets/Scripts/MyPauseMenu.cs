using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public bool canPause;
    public GameObject menu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    private void Awake()
    {
        menu.SetActive(false);
        canPause = true;
    }
    private void Update()
    {
        if(fps.canMove == true)
        {
            canPause = true; //quick fixing - after dialogue system closes won't let you pause for some reason
        }
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
}
