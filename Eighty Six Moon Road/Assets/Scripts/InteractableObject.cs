using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //Defines interactable objects

    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        //visualize interaction radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Interact()
    {
        //do an interaction here, usually pop up a reading/description, spawn dialogue etc.
        Debug.Log("Interacted with this object");
    }
}
