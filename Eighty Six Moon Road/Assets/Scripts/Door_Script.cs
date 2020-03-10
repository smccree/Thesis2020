using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public GameObject door;
    public DoorController door_control;
    private bool isOpen = false;
    public bool forcedLock = false;

    //public Animator door_anim;

    //make doors open and close
    public void CloseDoor()
    {
        if(isOpen == true)
        {
            if (door.name == "LibraryDoor")
            {
                door.transform.Rotate(0.0f, -90f, 0.0f, Space.Self);
                isOpen = false;
            }
            else
            {
                door.transform.Rotate(0.0f, -115f, 0.0f, Space.Self);
                isOpen = false;
            }
        } 
    }
    public void OpenDoor()
    {
        if(isOpen == false)
        {
            if (door.name == "LibraryDoor")
            {
                door.transform.Rotate(0.0f, 90f, 0.0f, Space.Self);
                isOpen = true;
            }
            else
            {
                door.transform.Rotate(0.0f, 115f, 0.0f, Space.Self);
                isOpen = true;
            }
        }  
    }

    //check to see whether we can open this door
    public void CheckStatus()
    {
        if(isOpen == false) //if the door is closed and it isn't forced to be locked.
        {
            if (door.name.Contains("Locked"))
            {
                if (door.name.Contains("Study"))
                {
                    if (door_control._studykey && forcedLock == false)
                    {
                        OpenDoor();
                    }
                    else
                    {
                        door_control.LockedDoor("study");
                    }
                }
                else if (door.name.Contains("Cellar"))
                {
                    if (door_control._cellarkey && forcedLock == false)
                    {
                        OpenDoor();
                    }
                    else
                    {
                        door_control.LockedDoor("cellar");
                    }
                }
                else if (door.name.Contains("Basement"))
                {
                    if (door_control._basementkey1 && door_control._basementkey2 && door_control._basementkey3 && forcedLock == false)
                    {
                        OpenDoor();
                    }
                    else
                    {
                        door_control.LockedDoor("basement");
                    }
                }
                else
                {
                    door_control.LockedDoor("null"); 
                }
            }
            else if (forcedLock == true)
            {
                door_control.LockedDoor("null");
            }
            else
            {
                OpenDoor();
            }
        }
        else
        {
            CloseDoor();
        }
        
    }
}
