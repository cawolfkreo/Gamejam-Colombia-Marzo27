using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //The number of columns the grid is going to have.
    [SerializeField]
    private int numXCells = 10;

    //The number of rows the grid is going to have.
    [SerializeField]
    private int numYCells = 10;

    //The size a single cell is going to have.
    private float cellSize;
    
    //The grid
    private Grid grid;

    //The position where the grid starts.
    [SerializeField]
    private Transform gridPosition;

    //The position of the floor where the tiles will be.
    [SerializeField]
    private GameObject floor;

    [SerializeField]
    private GameObject cubo;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = floor.GetComponent<Renderer>().bounds.size;

        cellSize = size.x / (float) numXCells;

        grid = new Grid(numXCells, numYCells, cellSize, gridPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition;
        bool isASuccesHit = GetMouseWorldPosition(Input.mousePosition, Camera.main, out mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (isASuccesHit)
            {                
                Vector3 position4Object = grid.GetWorldPositionCloserToCell(mousePosition);
                position4Object.y += 0.5f;
                AddOrRemoveObjectFromWorld(mousePosition, position4Object);              
            }            
        }
    }

    private void AddOrRemoveObjectFromWorld(Vector3 mousePosition, Vector3 position4Object)
    {
        if (grid.SetGridObject(mousePosition, cubo))
        {
            //main deme el nuevo objeto
            GameObject createdObject = Instantiate(cubo, position4Object, Quaternion.identity);
            createdObject.transform.parent = gridPosition.transform;
        }
    }

    private bool GetMouseWorldPosition(Vector3 screenPosition, Camera worldCamera, out Vector3 position)
    {
        Ray ray = worldCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            position = hitInfo.point;
            return true;
        }
        else
        {
            position = default;
            return false;
        }
    }
}
