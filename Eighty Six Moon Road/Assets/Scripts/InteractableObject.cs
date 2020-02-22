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
    private float rayDistance = 1f; //maximum distance for raycast hit
    public LayerMask interactLayer; //only shoot rays at interactables
    public bool interacting;
    public bool label; //there is or isn't a label on screen

    public DoorController doorcontrol;

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
        if (currentobj.name.Contains("Door"))
        {
            currentobj.GetComponent<Door_Script>().CheckStatus();
        }
        
        //show a text UI popup /readable
        else if(currentobj.name.Contains("Note"))
        {
            currentobj.GetComponent<TextUI>().HideLabel();
            label = false;
            currentobj.GetComponent<TextUI>().ShowTextUI();
        }
        
        //Player has found a key to unlock a locked door
        else if(currentobj.name.Contains("Key"))
        {
            Debug.Log("Player found Key");
            if(currentobj.name.Contains("Basement"))
            {
                if(currentobj.name == "BasementKey1")
                {
                    doorcontrol._basementkey1 = true;
                    currentobj.SetActive(false);
                }
                if (currentobj.name == "BasementKey2")
                {
                    doorcontrol._basementkey2 = true;
                    currentobj.SetActive(false);
                }
                if (currentobj.name == "BasementKey3")
                {
                    doorcontrol._basementkey3 = true;
                    currentobj.SetActive(false);
                }
            }
            else if(currentobj.name == "StudyKey")
            {
                doorcontrol._studykey = true;
                currentobj.SetActive(false);
            }
            else if(currentobj.name == "CellarKey")
            {
                doorcontrol._cellarkey = true;
                currentobj.SetActive(false);
            }
        }

        //A non-text based object. Will also show a textUI but a smaller popup readable.
        else if (currentobj.name.Contains("Object"))
        {
            currentobj.GetComponent<TextUI>().HideLabel();
            label = false;
            currentobj.GetComponent<TextUI>().ShowTextUI();
        }

        //v1 - lore cubes
        else if (currentobj.name.Contains("LoreCube"))
        {
            currentobj.GetComponent<TextUI>().HideLabel();
            label = false;
            currentobj.GetComponent<TextUI>().ShowTextUI();
            currentobj.GetComponent<LoreObject>().interacted = true;
            //Debug.Log("interacted with lorecube");
        }

        else if (currentobj.name.Contains("Convo") || currentobj.name.Contains("FinalCube"))
        {
            //only use once
            if (currentobj.GetComponent<ConversationObject>().interacted == false)
            {
                currentobj.GetComponent<ConversationTrigger>().TriggerDialogue();
                //Debug.Log("interacted with convo cube");
                currentobj.GetComponent<ConversationObject>().interacted = true;
            }
        }

        else
        {
            //Debug.Log("doing nothing.");
        }
        interacting = false; //done interacting
    }
}
