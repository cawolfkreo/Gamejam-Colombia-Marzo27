using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Roller"))
        {
            animation = GetComponent<Animator>();
            animation.Play("CarFall");
        }

    }
}
