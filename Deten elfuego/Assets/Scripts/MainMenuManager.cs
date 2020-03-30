using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private List<GameObject> ddObjects;

    private void Start()
    {
        ddObjects = new List<GameObject>();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        foreach(GameObject obj in ddObjects)
        {
            obj.SetActive(true);
        }

        SceneManager.LoadScene("MainScene");
    }

    public void addGameObject(GameObject obj)
    {
        if (!ddObjects.Contains(obj))
        {
            ddObjects.Add(obj);
        }        
    }
}
