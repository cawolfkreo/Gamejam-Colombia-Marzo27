using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    private readonly string mainScene = "MainMenu";
    private readonly string gridManager = "GridManager";
    private readonly string positionsManager = "PositionsManager";
    private readonly string gameStatusManager = "GameStatusManager";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != mainScene)
        {
            DestroySpecialObjects(gridManager);
            DestroySpecialObjects(positionsManager);
            DestroySpecialObjects(gameStatusManager);

            SceneManager.LoadScene(mainScene);
        }        
    }

    private void DestroySpecialObjects(string objectToDestroy)
    {
        Destroy(GameObject.Find(objectToDestroy));
    }
}
