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

    //The amount to change the angle
    [SerializeField, Range(0, 20)]
    private float deltaAngle;

    //The speed for the rotation.
    [SerializeField, Range(0, 20)]
    private float speed;

    //The position for the machines.
    private List<Transform> machinesPositions;

    //The objects created for the UI.
    private List<GameObject> createdObjects;

    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        machinesPositions = new List<Transform>();
        createdObjects = new List<GameObject>();

        store = GameObject.Find("store");

        gameObject.SetActive(false);

        for (int i = 1; i <= 3; ++i)
        {
            machinesPositions.Add(transform.Find("Machine" + i));
        }
    }

    private void Update()
    {
        Vector3 rotation = new Vector3(0f, deltaAngle, deltaAngle);
        foreach(GameObject machine in createdObjects)
        {
            machine.transform.Rotate(rotation * Time.deltaTime * speed);
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
            createdObjects.Add(objectToSet);

            objectToSet.transform.parent = store.transform;

            objectToSet.transform.position = machinesPositions[i].position;
            objectToSet.transform.rotation = machinesPositions[i].rotation;

            objectToSet.transform.localScale *= 20;
            
            ++i;
        }
    }
}