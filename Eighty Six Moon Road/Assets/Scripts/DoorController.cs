using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool _studykey;
    public bool _cellarkey;
    public bool _basementkey1;
    public bool _basementkey2;
    public bool _basementkey3;

    public DialoguePopup popupWindow;

    public GameObject[] Doors;
    
    public void LockedDoor(string door)
    {
        if(door == "study")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name_Revealed, DialogueLines.Locked_Study);
        }
        else if (door == "cellar")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name_Revealed, DialogueLines.Locked_Cellar);
        }
        else if (door == "basement")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name_Revealed, DialogueLines.Locked_Basement);
        }
        else
        {
            popupWindow.DictionaryPopup(DialogueLines.Name_Revealed, DialogueLines.Locked_Other);
        }
    }

    public void LockAllDoors()
    {
        foreach (GameObject door in Doors)
        {
            door.GetComponent<Door_Script>().forcedLock = true;
            door.GetComponent<Door_Script>().CloseDoor();
        }
    }

    public void UnlockDoors()
    {
        foreach(GameObject door in Doors)
        {
            door.GetComponent<Door_Script>().forcedLock = false;
        }
    }
}
