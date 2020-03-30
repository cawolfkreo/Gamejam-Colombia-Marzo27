using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainFour : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "book")
        {
            animation = GetComponent<Animator>();
            animation.Play("bookfall3");
        }
    }
}
