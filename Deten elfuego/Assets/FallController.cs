using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cubefall")
        {
            animation = GetComponent<Animator>();
            animation.Play("CarFall");
        }

    }
}
