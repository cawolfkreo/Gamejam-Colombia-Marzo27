using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GridManager gridManager;
    // Start is called before the first frame update
    void Start()
    {
 
        var mapObjects = GameObject.FindGameObjectsWithTag("MapObjectParent");

        foreach (GameObject mapObject in mapObjects)
        {
            foreach (Transform child in mapObject.transform)
            {
                if(child.tag == "MapObject")
                {
                    
                    gridManager.AddObject(child.transform.position, mapObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
