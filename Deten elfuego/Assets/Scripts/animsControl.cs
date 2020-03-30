using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animsControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform)
                {
                    var test = hit.transform;
                    var gameSelected = test.transform.gameObject;
                    if(gameSelected.name.Contains("Cutter"))
                    {
                        var anim = gameSelected.GetComponent<Animator>();
                        anim.Play("ArtifactTriggerAnim");
                        Debug.Log("test: " + gameSelected.name);
                    }
                }
            }
        }
    }
}
