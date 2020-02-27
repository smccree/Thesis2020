using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProperties : MonoBehaviour
{
    public string trigger_keyword;
    public bool interacted;

    public LoreObject loreobj1;
    public LoreObject loreobj2;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    public bool readytogo;
    public void Start()
    {
        if(this.name == "EntranceTrigger")
        {
            
            readytogo = true;
        }
        else
        {
            readytogo = false;
        }
    }
    public void Update()
    {
        Debug.Log("checking status of " + this.name);
        if(loreobj1.interacted && loreobj2.interacted && fps.canMove == true)
        {
            Debug.Log("Ready!");
            readytogo = true;
        }
        else
        {
            Debug.Log("Not ready!");
            Debug.Log(loreobj1.interacted + " " + loreobj2.interacted);
        }
    }
}
