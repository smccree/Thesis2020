using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDramaTrigger : MonoBehaviour
{
    //once all conversation cubes in the game have been viewed, spawn One Last Cube. The one true cube to rule them all.
    public GameObject triggerA;
    public GameObject triggerB;
    public GameObject triggerC;
    public GameObject triggerD;
    public GameObject triggerE;
    public GameObject finalcube;
    void Start()
    {
        finalcube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerA.GetComponent<ConversationObject>().interacted == true && triggerB.GetComponent<ConversationObject>().interacted == true
            && triggerC.GetComponent<ConversationObject>().interacted == true && triggerD.GetComponent<ConversationObject>().interacted == true
            && triggerE.GetComponent<ConversationObject>().interacted == true)
        {
            finalcube.SetActive(true);

        }
    }
}
