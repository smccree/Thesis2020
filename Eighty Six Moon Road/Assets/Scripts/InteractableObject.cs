using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
//Note: interaction works, but player can 'look away' from an object and still interact with it when within radius
//Need: Raycasting tech s/t need to be "focused" on the object and within its radius

    //Defines interactable objects
    public GameObject currentobj = null; //object we are currently interacting with
    //public GameObject label = null; //label for interactive object

    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        //visualize interaction radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1)) //if we are pressing the button
        {
            if (currentobj)
            {
                Interact(currentobj); //interact with current object
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("interactable"))
        {
            Debug.Log(collision.name);
            currentobj = collision.gameObject; //player is in range of interactable object

            //commented out: make label appear when in radius
            //label = currentobj.label;
            //label.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("interactable"))
        {
            if (collision.gameObject == currentobj)
            {
                currentobj = null; //player has walked out of range of interactable object
                Debug.Log(currentobj);

                //label.SetActive(false); //label disappears again
                //label = null; //no current label
            }

        }
    }
    public void Interact(GameObject currentobj)
    {
        //do an interaction here, usually pop up a reading/description, spawn dialogue etc.
        Debug.Log("Interacted with " + currentobj.name);

        currentobj.GetComponent<DialogueTrigger>().TriggerDialogue();

        //Theory here: delineate an action based on the object's name
        //poss: too many objects
        //nested loops

        //Solution: do different things based on objects names.
        //Example structure:

        //    if(currentobj.name.Contains("note") {
        //
        //         if(currentobj.name.Contains("one") {
        //              show note one stuff.
        //          }
        //         if (currentobj.name.Contains("two") {
        //              show note two stuff.
        //          }
        //    } (etcetera)
        }


    }
