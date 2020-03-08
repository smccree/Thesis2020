using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDramaTrigger_V2 : MonoBehaviour
{
    //once all the conversations possible have happened, trigger end drama
    public int num_triggered = 0;
    public GameObject end;
    bool endtriggered;
    int count = 800;
    void Start()
    {
        end.SetActive(false);
        endtriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endtriggered == false)
        {
            if (num_triggered >= 12)
            {
                StartCoroutine("EndCountdown");
                if(count <= 0)
                {
                    StopAllCoroutines();
                    end.SetActive(true);
                    endtriggered = true;
                }
            }
        }
    }

    IEnumerator EndCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
    }
}
