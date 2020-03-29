using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //TEMPORAL: El objeto que de momento se pone al hacer click.
    [SerializeField]
    private GameObject cubo;

    //The line manager prefab
    [SerializeField]
    private GameObject LinePrefab;

    //The object responsible for handling the gridlines.
    private GameObject GridLines;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 size = floor.GetComponent<Renderer>().bounds.size;

        GridLines = new GameObject("GridLines");
        GridLines.transform.parent = transform;

        cellSize = size.x / (float)numXCells;

        grid = new Grid(numXCells, numYCells, cellSize, gridPosition.position, this);
    }

    // Update is called once per frame
    void Update()
    {  
        if(SceneManager.GetActiveScene().name != "MainScene")
        {
            Vector3 mousePosition;
            bool isASuccesHit = GetMouseWorldPosition(Input.mousePosition, Camera.main, out mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (isASuccesHit)
                {
                    Vector3 position4Object = grid.GetWorldPositionCloserToCell(mousePosition);
                    position4Object.y += 0.5f;
                    AddObjectFromWorld(mousePosition, position4Object);
                }
            }
            else if (Input.GetMouseButton(1))
            {

                RemoveObjectFromWorld(mousePosition);

            }
        }
        else
        {
            GridLines.gameObject.SetActive(false);
        }
    }

    private void AddObjectFromWorld(Vector3 mousePosition, Vector3 position4Object)
    {
        GameObject createdObject = Instantiate(cubo, position4Object, Quaternion.identity);
        if (grid.SetGridObject(mousePosition, createdObject))
        {
            //TODO:
            //main deme el nuevo objeto
            createdObject.transform.parent = gridPosition.transform;
        }
        else
        {
            Destroy(createdObject);
        }
    }

    private void RemoveObjectFromWorld(Vector3 mousePosition)
    {
        var objectToDelete = grid.getObject(mousePosition);
        if(objectToDelete && !objectToDelete.CompareTag("MapObjectParent"))
        {
            grid.DeleteObject(mousePosition);
            Destroy(objectToDelete);            
        }
    }

    public void AddObject(Vector3 position, GameObject objectToAdd)
    {
        Vector3 position4Object = grid.GetWorldPositionCloserToCell(position);
        position4Object.y += 0.5f;
        grid.SetGridObject(position4Object, objectToAdd);
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

    public LineRenderManager createLineManager()
    {
        GameObject line = Instantiate(LinePrefab);

        line.transform.parent = GridLines.transform;

        return line.GetComponent<LineRenderManager>();
    }


}
