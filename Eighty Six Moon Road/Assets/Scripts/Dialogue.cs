using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //dialogue options for basic dialogue system

    [TextArea(3, 10)]

    public string name; //name of NPC talking to
    public string[] sentences;
}
