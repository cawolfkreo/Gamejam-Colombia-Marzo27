using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            animation = GetComponent<Animator>();
            animation.Play("CarJump");
            Debug.Log("entra al collision car");
        }

    }
}
