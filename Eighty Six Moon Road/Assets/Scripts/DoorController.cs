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
    // Start is called before the first frame update
    
    public void LockedDoor(string door)
    {
        if(door == "study")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name, DialogueLines.Locked_Study);
        }
        else if (door == "cellar")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name, DialogueLines.Locked_Cellar);
        }
        else if (door == "basement")
        {
            popupWindow.DictionaryPopup(DialogueLines.Name, DialogueLines.Locked_Basement);
        }
    }
}
