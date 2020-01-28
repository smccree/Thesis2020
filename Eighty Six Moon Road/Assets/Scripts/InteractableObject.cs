using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
//Note: interaction works, but player can 'look away' from an object and still interact with it when within radius
//Need: Raycasting tech s/t need to be "focused" on the object and within its radius

    //Defines interactable objects
    public GameObject currentobj = null; //object we are currently interacting with
    public float rayDistance = 3f; //maximum distance for raycast hit
    public LayerMask interactLayer; //only shoot rays at interactables
    public bool interacting;
    public bool label; //there is or isn't a label on screen

    public void Update()
    {
        //raycasting scripting
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; //the thing we hit

        //if ray hits something within the interact distance
        if(Physics.Raycast(ray, out hit, rayDistance, interactLayer))
        {
            currentobj = hit.collider.gameObject;
            Debug.Log(currentobj.name);
            if (currentobj.CompareTag("interactable"))
            {
                currentobj.GetComponent<TextUI>().ShowLabel(); //display label
                label = true;
            }
            
            if (Input.GetMouseButtonDown(1) && interacting == false) //if we are pressing the button
            {
                if(label == true)
                {
                    currentobj.GetComponent<TextUI>().HideLabel(); //hide label once started interacting
                    label = false;
                }
                
                interacting = true;
                Interact(currentobj); //interact with current object
            }
        }
        else
        {
            if(label == true)
            {
                currentobj.GetComponent<TextUI>().HideLabel();
                label = false;
            }
            currentobj = null;
            Debug.Log(currentobj);
        }
    }

    public void Interact(GameObject currentobj)
    {
        //do an interaction here, usually pop up a reading/description, spawn dialogue etc.
        Debug.Log("Interacted with " + currentobj.name);
        
        //added to script to account for opening doors (doors will not close after being opened)
        if (currentobj.name == "FrontDoor")
        {
            currentobj.GetComponent<Door_Script>().OpenDoor();
        }
        else if (currentobj.name == "Door")
        {
            //for now: blip out of existence (animation transform for front door doesn't work)
            currentobj.SetActive(false);
        }
        else if(currentobj.name.Contains("Note"))
        {
            currentobj.GetComponent<TextUI>().ShowTextUI();
        }
        else
        {
            currentobj.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        interacting = false; //done interacting
    }
}
