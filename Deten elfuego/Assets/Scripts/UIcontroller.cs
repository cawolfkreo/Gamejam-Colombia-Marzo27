using System;
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

    //GameObject to store the machines when created.
    private GameObject store;

    //This saves the currently selected machine.
    private GameObject selectedMachine;


    /**
     * This Attribute saves wich of the three lists of machine types is currently being used.
     * 0 -> No list is being used.
     * 1 -> Rollers is being used.
     * 2 -> Detonators is being used.
     * 3 -> Cutters is being used.
     */
    private short selectedList;

    void Awake()
    {
        machinesPositions = new List<Transform>();
        createdObjects = new List<GameObject>();
        store = GameObject.Find("store");

        selectedList = 0;
        selectedMachine = default;

        gameObject.SetActive(false);

        for (int i = 1; i <= 3; ++i)
        {
            machinesPositions.Add(transform.Find("Machine" + i));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
                
    }

    private void Update()
    {
        Vector3 rotation = new Vector3(0f, deltaAngle, 0f);
        foreach (GameObject machine in createdObjects)
        {
            machine.transform.Rotate(rotation * Time.deltaTime * speed);
        }

        CheckMachineClick();

    }

    private void CheckMachineClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit) && hit.transform)
            {
                string machineName = hit.transform.name;

                switch (selectedList)
                {
                    case 1:
                        SearchForMachine(machineName, rollers);
                        break;
                    case 2:
                        SearchForMachine(machineName, detonators);
                        break;
                    case 3:
                        SearchForMachine(machineName, cutters);
                        break;
                    default:
                        Honk();
                        break;
                }
            }
        }
    }

    private void SearchForMachine(string machineName, List<GameObject> machinesPrefabs)
    {
        machineName = machineName.Split('(')[0];

        foreach(GameObject prefab in machinesPrefabs)
        {
            if (prefab.name.Contains(machineName))
            {
                selectedMachine = prefab;
                break;
            }
        }
    }

    public GameObject GetMachinePrefab()
    {
        return selectedMachine;
    }

    public void DisplayRollers()
    {
        DisplayObjects(rollers, 1);
    }

    public void DisplayDetonators()
    {
        DisplayObjects(detonators, 2);
    }

    public void DisplayCutters()
    {
        DisplayObjects(cutters, 3);
    }

    public void Honk()
    {
        Debug.Log("HONK!");
    }

    private void DisplayObjects(List<GameObject> objectsToDisplay, short selected)
    {
        selectedList = selected;
        gameObject.SetActive(true);
        selectedMachine = default;

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

            GameObject screen = new GameObject();
            screen.transform.SetParent(objectToSet.transform);
            screen.name = objectToSet.name + "(-collider)";
            
            screen.transform.rotation = objectToSet.transform.rotation;
            screen.transform.position = machinesPositions[i].position + new Vector3(0, 0, -20);

            BoxCollider bc = screen.AddComponent<BoxCollider>();
            bc.size = new Vector3(55, 70, 15);
            bc.center = new Vector3(12, 15, -10);

            objectToSet.tag = "UIMachine";
            
            ++i;
        }
    }
}