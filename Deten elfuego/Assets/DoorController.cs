using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animation;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Contains("Roller1"))
        {
            animation = GetComponent<Animator>();
            animation.Play("doorchain");
        }
    }
}
