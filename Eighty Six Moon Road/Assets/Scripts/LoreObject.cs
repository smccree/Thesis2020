using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreObject : MonoBehaviour
{
    //script that applies properties onto lore objects s/t we can trigger events
    //based off of whether you've clicked on it before. Very simple script.

    public bool interacted;
    public GameObject button;
    
    void Start()
    {
        interacted = false;
    }

    private void Update()
    {
        if (interacted == true)
        {
            button.GetComponent<LoreObjectButton>().interacted = true;
        }
    }

}
