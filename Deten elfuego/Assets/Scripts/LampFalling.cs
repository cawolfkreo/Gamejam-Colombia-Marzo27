using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFalling : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(waitTwoSeconds());

    }

    // Update is called once per frame
    void Update()
    {

        float speed = 2;

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }


    IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSeconds(0);

        float speed = 1000;

        transform.Rotate(Vector3.up * speed * Time.deltaTime);

    }
}
