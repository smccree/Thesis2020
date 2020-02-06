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
    public GameObject label; //object label/description
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps; //for pausing player movement
    public GameObject loreobj; //the lore object this text ui is tied to
    //public GameObject eventtrigger; //conversation trigger (when interactables have been clicked and closed)
    public void Start()
    {
        panel.SetActive(false);
        label.SetActive(false); //initialize hiding on start
    }

    /*private void Update()
    {
        //check every frame if label should be false
        bool labelsetting = fps.GetComponent<InteractableObject>().label;
        if (labelsetting == true)
        {
            ShowLabel();
        }
        else
        {
            HideLabel();
        }
    }*/
    public void ShowTextUI()
    {
        
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

        //ShowLabel();

        //if we haven't already interacted with this object before
        /*if(loreobj.GetComponent<LoreObject>().interacted == false)
        {
            Debug.Log("interacted with this once.");
            loreobj.GetComponent<LoreObject>().interacted = true; //set as true so we know we've clicked / closed it before.
            //eventtrigger.GetComponent<EventConvoManager>().CheckforConvo();
        }*/
    }

    public void ShowLabel()
    {
        Debug.Log("showing label" + label.name);
        label.SetActive(true);
    }

    public void HideLabel()
    {
        Debug.Log("hiding label: " + label.name);
        label.SetActive(false);
    }
}
