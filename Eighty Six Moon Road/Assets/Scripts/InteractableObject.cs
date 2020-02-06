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
    private float rayDistance = 5f; //maximum distance for raycast hit
    public LayerMask interactLayer; //only shoot rays at interactables
    public bool interacting;
    public bool label; //there is or isn't a label on screen

    private void Start()
    {
        interacting = false;
        label = false;
    }
    public void Update()
    {
        
        // Debug.Log(currentobj);

        //raycasting scripting
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; //the thing we hit

        //if ray hits something within the interact distance
        if (Physics.Raycast(ray, out hit, rayDistance, interactLayer))
        {
            currentobj = hit.collider.gameObject;

            //bugged! Label won't disappear when you look away :( instead they stay open forever :(((
            /*
            if (currentobj.CompareTag("interactable") == true)
            {
                currentobj.GetComponent<TextUI>().ShowLabel();
            }*/
            //Debug.Log(currentobj.name);

            if (Input.GetMouseButtonDown(1) && interacting == false)
            {

                interacting = true;
                Interact(currentobj);
                
            }
            //reseting
        }
        currentobj = null;

        //Debug.Log(currentobj);
    }

    public void Interact(GameObject currentobj)
    {
        //do an interaction here, usually pop up a reading/description, spawn dialogue etc.
        //Debug.Log("Interacted with " + currentobj.name);
        
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
            currentobj.GetComponent<TextUI>().HideLabel();
            label = false;
            currentobj.GetComponent<TextUI>().ShowTextUI();
        }
        else if(currentobj.name == "Locked")
        {
            Debug.Log("Locked, huh? I wonder what must be inside.");
        }
        else if(currentobj.name.Contains("LoreCube"))
        {
            currentobj.GetComponent<TextUI>().HideLabel();
            label = false;
            currentobj.GetComponent<TextUI>().ShowTextUI();
            currentobj.GetComponent<LoreObject>().interacted = true;
            Debug.Log("interacted with lorecube");
        }
        else if(currentobj.name.Contains("Convo") || currentobj.name.Contains("FinalCube"))
        {
            //only use once
            if(currentobj.GetComponent<ConversationObject>().interacted == false)
            {
                currentobj.GetComponent<ConversationTrigger>().TriggerDialogue();
                Debug.Log("interacted with convo cube");
                currentobj.GetComponent<ConversationObject>().interacted = true;
            } 
        }
        else
        {
            Debug.Log("doing nothing.");
        }
        interacting = false; //done interacting
    }
}
