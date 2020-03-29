using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBooks : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "lamp")
        {
            animation = GetComponent<Animator>();
            animation.Play("book fall");
        }

    }
}
