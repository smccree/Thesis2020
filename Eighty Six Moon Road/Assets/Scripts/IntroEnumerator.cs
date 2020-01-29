using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroEnumerator : MonoBehaviour
{
    public TMP_Text dialogueText;
    public GameObject StartButton; //button -> activate once enumerator finishes w/time delay
    private string sentence = "This is the introduction to this game.\nI am testing out how this works, typing this out.\nI think when I implement this, I'll have the letter type in with an enumerator like I have the dialogue text from the Voice. That sounds like a good idea.\nThis is shaping up pretty well, I think, all things considered.\nCheers.";
    private float timeleft = 10; //for wait timer
    private float timer;
    private bool setTimer;

    void Start()
    {
        timer = timeleft; //initialize timer
        setTimer = true;
        StartButton.SetActive(false);
    }

    private void Update()
    {
        //countdown for sentence coroutine
        if (setTimer == true)
        {
            timer -= Time.deltaTime;
            //when timer hits 7 (3 seconds pass) start typing
            if (timer == 7)
            {
                StartCoroutine(TypeSentence(sentence)); //this isn't working so for now I'm just gonna have the text up
            }
            //when timer runs out stop timing and let players hit the start button
            if (timer < 0)
            {
                setTimer = false;
                StartButton.SetActive(true);
            }
        }

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
