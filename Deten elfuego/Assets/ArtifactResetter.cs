using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactResetter : MonoBehaviour
{
    //Animator del artefacto
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetArtifact();
        }
    }

    public void ResetArtifact()
    {
        if(!animator.isActiveAndEnabled)
        {
            animator.enabled = true;
        }
        animator.SetBool("triggered", false);
        animator.SetBool("reset", true);
    }
}
