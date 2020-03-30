using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    private bool isFrozen;

    private Vector3 vectorPosition;


    void Update()
    {
        if(isFrozen )
        {
            transform.position = vectorPosition;
        }
    }

    void Start()
    {
        isFrozen = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            vectorPosition = transform.position;
            isFrozen = true;
            canvas.SetActive(true);
        }

    }

}
