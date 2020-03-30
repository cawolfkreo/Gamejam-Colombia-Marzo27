using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollitionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Contains("Roller"))
        {
            var animation = plane.GetComponent<Animator>();
            animation.Play("doorchain");
            //animation = GetComponent<Animator>();
            //animation.Play("doorchain");
            Debug.Log("Entra COll BAR");
        }
        else
        {
            Debug.Log(collision.gameObject.name);

        }

    }
}
