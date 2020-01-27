using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public GameObject door;
    public Animator door_anim;

    //make doors open and close

    public void OpenDoor()
    {
        door_anim.SetBool("isOpen", true);
    }
}
