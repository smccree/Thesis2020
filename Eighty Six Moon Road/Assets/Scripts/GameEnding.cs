using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public DialogueManager manager;
    void Update()
    {
        Debug.Log("not the end");
        if(manager.isEnd)
        {
            Debug.Log("the end");
            this.GetComponent<GameManager>().TriggerEnd();
        }   
    }
}
