using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    //assumes button presses from starting screen (Start Menu with credits etc)
    public void StartGame()
    {
        //play the game by pressing start
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //choosing next scene in queue
    }

    public void ShowCredits()
    {
        //Go to credits scene
        SceneManager.LoadScene(4);
    }
    public void ReturntoMenu()
    {
        //return to main menu from main game scene
        SceneManager.LoadScene(0);
    }

    public void ReturnCredits()
    {
        //return to main menu from credits scene
        SceneManager.LoadScene(0);
    }

    public void TriggerEnd()
    {
        //from main scene to end scene
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        //close the game - won't work in Unity Editor
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
