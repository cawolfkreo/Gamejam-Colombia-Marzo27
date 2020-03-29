using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static int instance = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == 0 || this.gameObject.GetInstanceID() != instance)
        {
            instance = this.gameObject.GetInstanceID();
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
