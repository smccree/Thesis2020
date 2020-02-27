using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueConversation : MonoBehaviour
{
    //Triggers a conversation to start after meeting two conditions (interact with 2 lore objects)
    //NOTE : MAYBE INCLUDE DIALOGUE POP UP HERE - MANUALLY TURN IT OFF IF THERE'S ANOTHER CONVO BIT
    //i did this ^^ it's broken.
    public GameObject prevTrigger;
    public GameObject thisTrigger;
    public GameObject player;
    public DialoguePopup popup;

    private bool triggered;

    private void Start()
    {

        thisTrigger.SetActive(false);
        triggered = false;
    }
    void Update()
    {
        //every frame check whether lore object A and B have been interacted with. If they have, trigger a conversation
        //then set 'triggered' to true so that it will stop checking.

        if (triggered == false)
        {
            if (prevTrigger.GetComponent<TriggerProperties>().interacted == true)
            {
                //popup.count = 3;
                thisTrigger.SetActive(true);
                Destroy(prevTrigger);
                player.GetComponent<EventTriggerControl>().eventTrigger = thisTrigger;
                triggered = true;
            }
        }
    }
}
