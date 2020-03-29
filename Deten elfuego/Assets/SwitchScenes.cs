﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("MainScene");
        }
        else if(Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("PlayerScene");
        }
    }
}