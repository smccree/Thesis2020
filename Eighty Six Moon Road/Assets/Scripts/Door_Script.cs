using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public GameObject door;
    public DoorController door_control;

    //public Animator door_anim;

    //make doors open and close

    public void OpenDoor()
    {
        //door.SetActive(false); //temp
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

    //check to see whether we can open this door
    public void CheckStatus()
    {
        if(door.name.Contains("Locked"))
        {
            if(door.name.Contains("Study") && door_control._studykey)
            {
                OpenDoor();
            }
            else if (door.name.Contains("Cellar") && door_control._cellarkey)
            {
                OpenDoor();
            }
            else if (door.name.Contains("Basement"))
            {
                if(door_control._basementkey1 && door_control._basementkey2 && door_control._basementkey3)
                {
                    OpenDoor();
                }
            }
            else
            {
                Debug.Log("Locked, huh? I wonder what must be inside. The key must be around here somewhere...");
                //Show 'door is locked' pop up for this specific door
            }
        }
        else
        {
            OpenDoor();
        }
    }
}
