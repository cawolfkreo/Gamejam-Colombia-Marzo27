using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGridManager : MonoBehaviour
{
    // Start is called before the first frame update
    GridManager gridManager;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = new GridManager();
        var mapObjects = GameObject.FindGameObjectsWithTag("MapObject");

        foreach (GameObject mapObject in mapObjects)
        {
            foreach (Transform child in mapObject.transform)
            {
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
