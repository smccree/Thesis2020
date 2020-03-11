using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool hasviewed;
    public GameObject eventTrigger = null;
    public EndDramaTrigger_V2 endDrama; //for end drama later
    private void Start()
    {
        //hasviewed = false;
    }
    private void OnTriggerStay(Collider collider)
    {
        //triggering a conversation with voice and player
        if (collider.CompareTag("EventTrigger") == true)
        {
            if(collider.name == "EndDramaTrigger")
            {
                //hide text UI + set player as not interacting with stuff anymore
                //not sure if this works but leaving it in
                if(this.GetComponent<InteractableObject>().interacting == true)
                {
                    this.GetComponent<InteractableObject>().currentobj.GetComponent<TextUI>().HideTextUI();
                    this.GetComponent<InteractableObject>().interacting = false;
                }
                Debug.Log("triggering end of the game");
                eventTrigger = collider.gameObject;
                eventTrigger.GetComponent<ConversationTrigger>().TriggerDialogue();
                Destroy(eventTrigger);
            }
            else if(collider.GetComponent<TriggerProperties>().readytogo == true)
            {
                Debug.Log("This collider is ready to go! This collider is named " + collider.name);
                eventTrigger = collider.gameObject;
                eventTrigger.GetComponent<ConversationTrigger>().TriggerDialogue();
                Destroy(eventTrigger);
            }
            
        }
        //triggering a pop up dialogue from voice
        else if (collider.CompareTag("PopUpDialogue") == true)
        {
            eventTrigger = collider.gameObject;
            //Debug.Log(eventTrigger.name);
            Debug.Log("triggering dialogue....");
            eventTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
            //Destroy(eventTrigger);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(eventTrigger != null)
        {
            eventTrigger = null;
            Debug.Log(eventTrigger);
        }
        
    }
}
