using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConvoManager : MonoBehaviour
{
    //Triggers a conversation to start after meeting two conditions (interact with 2 lore objects)

    public GameObject loreA;
    public GameObject loreB;
    public GameObject trigger;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    private bool triggered;

    //private bool used;

    private void Awake()
    {
        
        trigger.SetActive(false);
        triggered = false;
    }
    void Update()
    {
        //every frame check whether lore object A and B have been interacted with. If they have, trigger a conversation
        //then set 'triggered' to true so that it will stop checking.

        if(triggered == false) {
            if (loreA.GetComponent<LoreObject>().interacted == true && loreB.GetComponent<LoreObject>().interacted == true)
            {
                if (fps.canMove == true) // s/t conversation pop up doesn't start while interacting with an object/frozen
                {
                    Debug.Log("Trigger Spawner Triggering Conversation....");
                    trigger.SetActive(true);
                    triggered = true;
                }
            }
        }
    }
}
