using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConvoManager : MonoBehaviour
{
    //Triggers a conversation to start after meeting two conditions (interact with 2 lore objects)

    public GameObject loreA;
    public GameObject loreB;
    public GameObject trigger;
    //private bool used;

    private void Start()
    {
        
        trigger.SetActive(false);
    }
    void Update()
    {
        //every frame check whether lore object A and B have been interacted with. If they have, trigger a conversation
        //then set 'used' to true so that it will stop checking.

        //if(used == false) {
        //Debug.Log("checking status...");
        if (loreA.GetComponent<LoreObject>().interacted == true && loreB.GetComponent<LoreObject>().interacted == true)
        {
            trigger.SetActive(true);
            
        }
        
    }
}
