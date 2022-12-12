using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testing : MonoBehaviour
{
    public float cellSize = 1f; // The size of each grid cell
    public Color gridColor = Color.white; // The color of the grid lines
    public int gridWidth = 10; // The number of cells wide the grid will be
    public int gridHeight = 10; // The number of cells tall the grid will be

    void Start()
    {
        OnDrawGizmos();
    }

    void OnDrawGizmos()
    {
        // Set the color of the grid lines
        Gizmos.color = gridColor;

        // Loop through the grid width and height
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Calculate the position of the current grid cell
                Vector3 cellPos = new Vector3(x, 0, y) * cellSize;

                // Draw a line for the x and y axes of the current cell
                Gizmos.DrawLine(cellPos, cellPos + Vector3.right * cellSize);
                Gizmos.DrawLine(cellPos, cellPos + Vector3.forward * cellSize);
            }
        }
    }
}



