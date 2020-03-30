﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
