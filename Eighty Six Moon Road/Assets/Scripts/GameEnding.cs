using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public DialogueManager manager;
    public Animator anim;
    void Update()
    {
        //Debug.Log("not the end");
        if(manager.isEnd)
        {
            //Debug.Log("the end");
            FadeToBlack();
        }   
    }

    void FadeToBlack()
    {
        anim.SetTrigger("FadeOut");
        
    }

    void EndGame()
    {
        this.GetComponent<GameManager>().TriggerEnd();
    }
}
