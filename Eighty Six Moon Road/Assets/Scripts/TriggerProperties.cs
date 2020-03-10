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
    public void Awake()
    {
        if(this.name == "EntranceTrigger")
        {
            
            readytogo = true;
        }
        else
        {
            Debug.Log(this.name + " is not ready to go");
            readytogo = false;
        }
    }
    public void Update()
    {
        if(loreobj1.interacted && loreobj2.interacted && fps.canMove == true)
        {
            Debug.Log(this.name + " is ready to go");
            readytogo = true;
        }
        else
        {
            //Debug.Log(loreobj1.interacted + " " + loreobj2.interacted);
        }
    }
}
