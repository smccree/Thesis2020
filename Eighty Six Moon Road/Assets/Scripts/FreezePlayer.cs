﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    //freeze player movmement for dialogue system
    //all of this is called internally by the dialogue manager system
    public CharacterController fps;

    public void Freeze()
    {
        //disable fps controller movement
        fps.enabled = false;
        ActivateControls(true); //trigger text controls
    }

    public void Unfreeze()
    {
        //re-enable fps controller movement by re-enabling the fps controller game object/scripts
        fps.enabled = true;
        ActivateControls(false); //disable text controls
    }
    public void ActivateControls(bool boolean)
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
