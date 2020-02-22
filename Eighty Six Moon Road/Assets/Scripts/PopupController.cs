using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    //gameobject attached to all the dialogue popups in the game
    //she will make passing remarks at 10? different points in the game
    //conditions = the objects you have to be looking at ("currentobj") to trigger the pop up
    public GameObject condition1;
    public GameObject condition2;
    public GameObject condition3;
    public GameObject condition4;
    public GameObject condition5;
    public GameObject condition6;
    public GameObject condition7;
    public GameObject condition8;
    public GameObject condition9;
    public GameObject condition10;

    public GameObject popup1;
    public GameObject popup2;
    public GameObject popup3;
    public GameObject popup4;
    public GameObject popup5;
    public GameObject popup6;
    public GameObject popup7;
    public GameObject popup8;
    public GameObject popup9;
    public GameObject popup10;

    public GameObject Player;

    //whether you have triggered this specific popup
    private bool triggered1 = false;
    private bool triggered2 = false;
    private bool triggered3 = false;
    private bool triggered4 = false;
    private bool triggered5 = false;
    private bool triggered6 = false;
    private bool triggered7 = false;
    private bool triggered8 = false;
    private bool triggered9 = false;
    private bool triggered10 = false;

    private int num_triggered = 0; //total popups triggered

    void Update()
    {
        //every frame check whether lore object A and B have been interacted with. If they have, trigger a conversation
        //then set 'triggered' to true so that it will stop checking.
        if(num_triggered < 10)
        {
            PopupStatus();
        }
    }

    public void PopupStatus()
    {
        GameObject currentobj = Player.GetComponent<InteractableObject>().currentobj;
        bool canMove = Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().canMove;

        //if player has a current object and can move
        if (currentobj != null && canMove == true)
        {
            //check if the current object matches a pop up condition
            //if the player hasn't triggered the pop up before then display it
            //then increment num_triggered s/t system knows when to stop checking for pop ups

            if(currentobj.name == condition1.name && triggered1 == false)
            {
                popup1.SetActive(true);
                triggered1 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition2.name && triggered2 == false)
            {
                popup2.SetActive(true);
                triggered2 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition3.name && triggered3 == false)
            {
                popup3.SetActive(true);
                triggered3 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition4.name && triggered4 == false)
            {
                popup4.SetActive(true);
                triggered4 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition5.name && triggered5 == false)
            {
                popup5.SetActive(true);
                triggered5 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition6.name && triggered6 == false)
            {
                popup6.SetActive(true);
                triggered6 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition7.name && triggered7 == false)
            {
                popup7.SetActive(true);
                triggered7 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition8.name && triggered8 == false)
            {
                popup8.SetActive(true);
                triggered8 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition9.name && triggered9 == false)
            {
                popup9.SetActive(true);
                triggered9 = true;
                num_triggered++;
            }
            else if (currentobj.name == condition10.name && triggered10 == false)
            {
                popup10.SetActive(true);
                triggered10 = true;
                num_triggered++;
            }
            else
            {
                Debug.Log("currentobj doesn't match. Doing nothing.");
            }
        }
    }
}
