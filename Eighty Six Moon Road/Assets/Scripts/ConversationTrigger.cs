using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        Debug.Log("triggering dialogue in Dialogue Trigger Script...");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
