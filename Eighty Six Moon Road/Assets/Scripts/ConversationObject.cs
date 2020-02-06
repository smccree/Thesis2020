using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationObject : MonoBehaviour
{
    //initializer class for objects that trigger conversations to start for player/voice
    //can only use the object once
    public bool interacted;


    void Start()
    {
        interacted = false;
    }
}
