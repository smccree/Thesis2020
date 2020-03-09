using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    /* functionality to display a pop up UI image/text associated with an interactable
        used for Notes, objects, etc.
    */
    public GameObject panel; //screen overlay - we're in reading mode
    public Image popup; //image to display
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps; //for pausing player movement
    public GameObject loreobj; //the lore object this text ui is tied to
    //public GameObject eventtrigger; //conversation trigger (when interactables have been clicked and closed)
    public void Start()
    {
        panel.SetActive(false);
    }

    public void ShowTextUI()
    {
        Debug.Log("Showing Text");
        panel.SetActive(true);
        popup.GetComponent<Animator>().SetBool("isOpen", true);
        fps.canMove = false;
        fps.m_MouseLook.lockCursor = false;

        
    }

    public void HideTextUI()
    {

        panel.SetActive(false);
        popup.GetComponent<Animator>().SetBool("isOpen", false);
        fps.canMove = true;
        fps.m_MouseLook.lockCursor = true;
        loreobj.GetComponent<LoreObject>().interacted = true;
    }
}
