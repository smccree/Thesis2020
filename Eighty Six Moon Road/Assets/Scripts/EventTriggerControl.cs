using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool hasviewed;
    public GameObject eventTrigger = null;
    private void Start()
    {
        //hasviewed = false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.tag);
        //triggering a conversation with voice and player
        if (collider.CompareTag("EventTrigger") == true)
        {
            eventTrigger = collider.gameObject;
            //Debug.Log(eventTrigger.name);
            Debug.Log("triggering conversation....");
            eventTrigger.GetComponent<ConversationTrigger>().TriggerDialogue();
            Destroy(eventTrigger);
        }
        //triggering a pop up dialogue from voice
        else if (collider.CompareTag("PopUpDialogue") == true)
        {
            eventTrigger = collider.gameObject;
            //Debug.Log(eventTrigger.name);
            Debug.Log("triggering dialogue....");
            eventTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(eventTrigger);
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
