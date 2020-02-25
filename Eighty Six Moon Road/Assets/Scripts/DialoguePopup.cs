using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePopup : MonoBehaviour
{
    //Functionality for dialogue pop-ups - observations from the voice that do not prompt a conversation with the player
    //Player movement is not paused, dialogue disappears after a few seconds
    
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject popupDialogueBox; //transparent

    private string sentence; //the dialogue line (don't need a queue since all pop ups will be 1 sentence)
    private int count; //countdown time while count > 0
    private bool popup_isopen;
    void Start()
    {
        popupDialogueBox.SetActive(false);
    }

    private void Update()
    {
        if(count <= 0)
        { 
            if(popup_isopen == true)
            {
                StopCoroutine("Countdown");
                popupDialogueBox.SetActive(false);
                popup_isopen = false;
            }
            
        }
    }
    public void Popup(Dialogue dialogue)
    {
        sentence = dialogue.sentences[0]; //will always have length 1

        nameText.text = dialogue.name;
        popupDialogueBox.SetActive(true);
        popup_isopen = true;

        StopAllCoroutines();
        count = 10;
        //type letters 1 by 1 on screen and start countdown timer
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine("Countdown");
    }

    public void DictionaryPopup(string name, string sentence)
    {

        nameText.text = name;
        popupDialogueBox.SetActive(true);
        popup_isopen = true;

        StopAllCoroutines();
        count = 10;
        //type letters 1 by 1 on screen and start countdown timer
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine("Countdown");
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

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
    }
}
