using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    public Transform sparkle;
    public Transform fire1;
    public Transform fire2;
    public Transform fire3;
    public Transform fireMaximum;

    // Start is called before the first frame update
    void Start()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
        fire1.GetComponent<ParticleSystem>().enableEmission = false;
        fire2.GetComponent<ParticleSystem>().enableEmission = false;
        fire3.GetComponent<ParticleSystem>().enableEmission = false;
        fireMaximum.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "charger")
        {
            sparkle.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSparkles());
        }
    }

    IEnumerator stopSparkles()
    {
        yield return new WaitForSeconds(.4f) ;
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
        fire1.GetComponent<ParticleSystem>().enableEmission = true;
        fire2.GetComponent<ParticleSystem>().enableEmission = true;
        fire3.GetComponent<ParticleSystem>().enableEmission = true;
        fireMaximum.GetComponent<ParticleSystem>().enableEmission = true;

    }


}
