using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDialogueLines : MonoBehaviour
{
    void Awake()
    {
        DialogueLines.Initialize();
    }
}
