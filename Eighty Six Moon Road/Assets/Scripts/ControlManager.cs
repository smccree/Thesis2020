using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    //toggles whether control scheme is shown on screen
    public GameObject controls;
    private int count;
    void Start()
    {
        if(controls.name == "EnterReminder")
        {
            controls.SetActive(false);
        }
        else
        {
            ShowControls();
        }
        
    }

    private void Update()
    {
        if(count <= 0)
        {
            StopCoroutine("Countdown");
            HideControls();
        }
    }
    public void ShowControls()
    {
        controls.SetActive(true);

        StopAllCoroutines();
        count = 10;

        StartCoroutine("Countdown");
    }

    public void HideControls()
    {
        controls.SetActive(false);
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
    }
}
