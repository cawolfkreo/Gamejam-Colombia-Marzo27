using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    //Amount of columns the grid is going to have.
    private int width;

    //Amount of rows the grid is going to have.
    private int height;

    private float cellSize;

    //The array for the objects inside the grid.
    private GameObject[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new GameObject[this.width, this.height];

        Vector3 cellPosition;

        for(int i = 0; i < gridArray.GetLength(0); ++i)
        {
            for (int j = 0; j < gridArray.GetLength(1); ++j)
            {
                cellPosition = GetWorldPosition(i, j);
            }
        }
    }

    //Returns the world position for a given element 
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public int test()
    {
        return 42;
    }
}
