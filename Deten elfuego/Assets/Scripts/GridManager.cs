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
    [SerializeField]
    private float cellSize = 5f;
    
    //The grid
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(numXCells, numXCells, cellSize);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grid.test());
    }
}
