using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public bool canPause = true;
    public GameObject menu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    private void Start()
    {
        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    void ResumeGame()
    {
        menu.SetActive(false);
        isPaused = false;
        fps.canMove = true;
    }
}
