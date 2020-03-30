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
            SceneManager.sceneLoaded += OnSceneLoaded;
            return;
        }
        Destroy(this.gameObject);
    }

    // called when the game is terminated
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("PlayerScene"))
        {
            ResetGridOnSceneChange();
        }                
    }

    private void ResetGridOnSceneChange()
    {
        Transform gridPosition = getGridPosition();

        //Makes sure the gridposition was found. Otherwise it won't execute anythjing with it.
        if (gridPosition)
        {
            ResetArtifacts(gridPosition);
        }
    }

    private Transform getGridPosition()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Equals("gridPosition"))
            {
                return child;
            }
        }

        return null;
    }

    private void ResetArtifacts(Transform gridPosition)
    {
        foreach (Transform Artifact in gridPosition)
        {
            ArtifactResetter resetter = Artifact.GetComponent<ArtifactResetter>();
            if (resetter)
            {
                resetter.ResetArtifact();
            }
        }
    }
}
