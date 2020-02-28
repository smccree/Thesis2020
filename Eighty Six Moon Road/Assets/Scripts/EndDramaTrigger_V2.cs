using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDramaTrigger_V2 : MonoBehaviour
{
    //once all the conversations possible have happened, trigger end drama
    public int num_triggered = 0;
    public GameObject end;
    bool endtriggered;
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
                end.SetActive(true);
                endtriggered = true;
            }
        }
    }
}
