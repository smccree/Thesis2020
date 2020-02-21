using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public GameObject door;
    //public Animator door_anim;

    //make doors open and close

    public void OpenDoor()
    {
        Debug.Log("Opening Door");
        if(door.name == "LibraryDoor")
        {
            door.transform.Rotate(0.0f, 90f, 0.0f, Space.Self);
        }
        else
        {
            door.transform.Rotate(0.0f, 115f, 0.0f, Space.Self);
        }
    }
}
