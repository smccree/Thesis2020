using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    /* functionality to display a pop up UI image/text associated with an interactable
        used for Notes, objects, etc.
    */

    public Image popup; //image to display
    public GameObject label; //object label/description
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController
        
        
        
        
        
        
        
        
        
        
        
        
        
   fps; //for pausing player movement

    public void Start()
    {
        label.SetActive(false); //initialize hiding on start
    }
    public void ShowTextUI()
    {
        popup.GetComponent<Animator>().SetBool("isOpen", true);
        fps.canMove = false;
        fps.m_MouseLook.lockCursor = false;
    }

    public void HideTextUI()
    {
        popup.GetComponent<Animator>().SetBool("isOpen", false);
        fps.canMove = true;
        fps.m_MouseLook.lockCursor = true;
    }

    public void ShowLabel()
    {
        label.SetActive(true);
    }

    public void HideLabel()
    {
        label.SetActive(false);
    }
}
