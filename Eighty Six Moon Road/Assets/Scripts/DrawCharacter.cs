using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCharacter : MonoBehaviour
{
    // Wrapping Character Controller with a Wire Frame
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    CharacterController player;
    private void Start()
    {
        player = fps.GetComponent<CharacterController>();
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, player.radius);
    }
    void OnDrawGizmos()
        {
            CharacterController cc = GetComponent<CharacterController>();
            Gizmos.color = Color.yellow;

            if (cc.height > cc.radius * 2)
                Gizmos.DrawWireCube(transform.position, new Vector3(cc.radius * 2, cc.height, cc.radius * 2));
            else //if (cc.radius * 2 > cc.height || cc.radius * 2 == cc.height)
                Gizmos.DrawWireSphere(transform.position, cc.radius);
        }

}
