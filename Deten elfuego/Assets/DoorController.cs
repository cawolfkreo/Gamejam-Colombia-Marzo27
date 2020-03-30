using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("Roller"))
        {
            animation = GetComponent<Animator>();
            animation.Play("doorchain");
            Debug.Log("Entra COll DOOR");
        }


    }
}
