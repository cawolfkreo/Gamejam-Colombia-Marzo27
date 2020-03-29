using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFalling : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hips")
        {
            animation = GetComponent<Animator>();
            animation.Play("lamp falling");
            Debug.Log("entra al collision");
        }
    }

}
