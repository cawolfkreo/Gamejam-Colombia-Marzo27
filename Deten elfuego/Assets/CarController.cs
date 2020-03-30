using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private Animator animation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "door")
        {
            animation = GetComponent<Animator>();
            animation.Play("car chain");
            Debug.Log("entra al collision car");
        }

    }
}
