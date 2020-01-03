using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //this might b an unnecessary script

    //freeze player movmement for dialogue system
    //all of this is called internally by the dialogue manager system
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    public bool isFrozen;
    public void Update()
    {
        //check each frame if player should be frozen
        if (isFrozen == true)
        {
            fps.canMove = false;
        }
        //Debug.Log(isFrozen);
    }
    private void Freeze()
    {
        //disable fps controller movement
        ActivateControls(true); //trigger text controls
    }

    private void Unfreeze()
    {
        ActivateControls(false); //disable text controls
    }
    private void ActivateControls(bool boolean)
    {
        //call to activate or deactivate text box controls
        if (boolean == true)
        {
            //enter = submit text/view next sentence
            //keyboard controls for text input enabled
        }
        if (boolean == false)
        {
            //do the opposite
        }
    }
}
