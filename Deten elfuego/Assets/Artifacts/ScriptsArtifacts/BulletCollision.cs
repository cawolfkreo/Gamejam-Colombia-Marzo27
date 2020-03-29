using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    /*Sistema de particulas de la bala*/
    public ParticleSystem powPSys;
    /*animator de la bala*/
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
 
        powPSys.Play();

    }
}
