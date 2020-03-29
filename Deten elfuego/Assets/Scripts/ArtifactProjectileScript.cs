using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactProjectileScript : MonoBehaviour
{
    /* Animator del artefacto que contien el projectil*/
    public Animator animatorProjectil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StopProjectile()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        animatorProjectil.enabled = false;
    }
}
