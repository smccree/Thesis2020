using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreObjectButton : MonoBehaviour
{
    public bool interacted;
    public GameObject noteUI;

    void Start()
    {
        interacted = false;
        
    }

    public void TextPopup()
    {
        
        noteUI.GetComponent<Animator>().SetBool("isOpen", true);
    }

    public void ClosePopup()
    {
        
        noteUI.GetComponent<Animator>().SetBool("isOpen", false);
    }
}
