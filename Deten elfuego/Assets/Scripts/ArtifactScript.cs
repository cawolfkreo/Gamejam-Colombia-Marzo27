using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactScript : MonoBehaviour
{
    
    /*El string puede tomar 3 valores: Cortador, Rodador o Detonador. Indica que activa el artefacto*/
    public string triggeredBy;

    /*Animator del artefacto*/
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(triggeredBy))
        {
            animator.SetBool("triggered", true);
        }
    }
}
