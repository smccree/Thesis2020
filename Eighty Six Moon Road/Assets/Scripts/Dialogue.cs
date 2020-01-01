using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //dialogue options for basic dialogue system

    //will eventually be compiled into a .txt file
    //end result: number goes to a line in the .txt file and the sentence returned is that line
    //for now: edit in console
    public string name; //name of NPC talking to

    [TextArea(3, 10)]
    public string[] sentences;

}
