﻿using System.Collections;
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

    //The origin position to render the grid.
    private Vector3 originPosition;

    //Creates the grid in the world.
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new GameObject[this.width, this.height];

        Vector3 cellPositionX0Y0;
        Vector3 cellPositionX0Y1;
        Vector3 cellPositionX1Y0;

        for (int i = 0; i < gridArray.GetLength(0); ++i)
        {
            for (int j = 0; j < gridArray.GetLength(1); ++j)
            {
                cellPositionX0Y0 = GetWorldPosition(i, j);
                cellPositionX0Y1 = GetWorldPosition(i, j + 1);
                cellPositionX1Y0 = GetWorldPosition(i + 1, j);

                Debug.DrawLine(cellPositionX0Y0, cellPositionX0Y1, Color.white, 100f);
                Debug.DrawLine(cellPositionX0Y0, cellPositionX1Y0, Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    //Returns the world position for a given element 
    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }    

    public Vector3 GetWorldPositionCloserToCell(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetWorldPosition(x, y) + new Vector3(cellSize, 0, cellSize) * .5f;      //Makes the object appear in the middle of the cell (half of x and half of y)
    }

    public bool SetGridObject(Vector3 worldPosition, GameObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return SetGridObject(x, y, value);
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    private bool SetGridObject(int x, int y, GameObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if(gridArray[x, y] == null)
            {
                gridArray[x, y] = value;
                return true;
            }
        }

        return false;
    }

    public GameObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }

    public GameObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default;
        }
    }

}
