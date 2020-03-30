using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPosManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static int instance = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == 0)
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
