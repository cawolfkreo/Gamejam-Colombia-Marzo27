using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    //The list of prefabs to be rollers
    [SerializeField]
    private List<GameObject> rollers;

    //The list of prefabs to be rollers
    [SerializeField]
    private List<GameObject> detonators;
    //The list of prefabs to be rollers

    [SerializeField]
    private List<GameObject> cutters;

    //The position for the machines.
    private List<GameObject> machinesPositions;

    //The objects created for the UI.
    private List<GameObject> createdObjects;

    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        machinesPositions = new List<GameObject>();
        createdObjects = new List<GameObject>();

        store = GameObject.Find("store");

        gameObject.SetActive(false);

        for (int i = 0; i < 3; ++i)
        {
            machinesPositions.Add(GameObject.Find("Machine" + i));
        }
    }

    public void DisplayRollers()
    {
        DisplayObjects(rollers);
    }

    public void DisplayDetonators()
    {
        DisplayObjects(detonators);
    }

    public void DisplayCutters()
    {
        DisplayObjects(cutters);
    }

    private void DisplayObjects(List<GameObject> objectsToDisplay)
    {
        gameObject.SetActive(true);

        foreach (GameObject created in createdObjects)
        {
            Destroy(created);
        }

        createdObjects.Clear();

        GameObject objectToSet;
        int i = 0;
        foreach (GameObject prefab in objectsToDisplay)
        {
            objectToSet = Instantiate(prefab);

            objectToSet.transform.position = machinesPositions[i].transform.position;

            objectToSet.transform.parent = store.transform;

            createdObjects.Add(objectToSet);
            ++i;
        }
    }
}