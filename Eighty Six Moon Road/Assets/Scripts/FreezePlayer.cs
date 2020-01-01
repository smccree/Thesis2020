using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    //freeze player movmement for dialogue system
    //all of this is called internally by the dialogue manager system
    public GameObject FPScontroller;

    public void Freeze()
    {
        //disable fps controller movement by disabling the fps controller game object/scripts
        //i have a feeling this may not work
            //--> OKAY it kind of worked. It's clunky and feels broken but it works.
        FPScontroller.SetActive(false);
        ActivateControls(true); //trigger text controls
    }

    public void Unfreeze()
    {
        //re-enable fps controller movement by re-enabling the fps controller game object/scripts
        FPScontroller.SetActive(true);
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
