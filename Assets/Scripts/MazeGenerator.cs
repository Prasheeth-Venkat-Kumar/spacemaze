using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGenerator : MonoBehaviour
{
    // 2D array to hold the maze
    private int[,] maze;

    // list of maze tiles
    private List<GameObject> mazeTiles = new List<GameObject>();

    // The size of the maze (number of cells)
    public Vector2Int size = new Vector2Int(10, 10);

    // The probability that a given cell will be blocked
    public float obstacleProbability = 0.0001f;

    // The rate at which the maze will degrade over time (in seconds)
    public float degradationRate = 2000.0f;

    // The time at which the maze was last updated
    // private float lastUpdateTime = 0.0f;

    // The prefab to use for the floor tiles
    public GameObject floorTilePrefab;

    // The prefab to use for the wall tiles
    public GameObject wallTilePrefab;

    void Start()
    {
        // Generate the initial maze, every 45 seconds
        // GenerateMaze();
        InvokeRepeating("GenerateMaze", 1f, 45f);
    }

    void Update()
    {
        // every 5 seconds, call handleMaze()
    }

    void GenerateMaze()
    {
        // Create a new maze
        maze = new int[size.x, size.y];

        // Loop through each cell in the maze
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                // Check if the current cell should be an obstacle
                if (Random.value < obstacleProbability)
                {
                    // Set the cell to be an obstacle
                    maze[x, y] = 1;
                }

                // Instantiate a floor or wall tile at the current cell
                if(maze[x, y] == 1){
                    // add to mazeTiles
                    mazeTiles.Add(Instantiate(wallTilePrefab, new Vector3(x-10, y-5, 0), Quaternion.identity));
                }
  
            }
        }
    }


//     void DegradeMaze()
//     {
//         // Loop through each cell in the maze
//         for (int x = 0; x < size.x; x++)
//         {
//             for (int y = 0; y < size.y; y++)
//             {
//                 // Check if the current cell is an obstacle
//                 if (maze[x, y] == 1)
//                 {
//                     // Check if the current cell should be cleared
//                     if (Random.value < 0.05f)
//                     {
//                         // Clear the cell
//                         maze[x, y] = 0;

//                         // Destroy the wall tile at the current cell
//                         Destroy(GameObject.Find("WallTile (" + x + "," + y + ")"));

//                         // Instantiate a floor tile at the current cell
//                         Instantiate(floorTilePrefab, new Vector3(x, y, 0), Quaternion.identity);
//                     }
//                 }
//             }
//         }
//     }
// }

    // void DegenerateMaze()
    // {
    //     // call degenerate on each maze tile in the mazeTiles array, foreach loop
    //     foreach(GameObject tile in mazeTiles){
    //         tile.GetComponent<MazeBlock>().Degenerate();
    //     }
    //     // clear the mazeTiles list
    //     mazeTiles.Clear();

    // }

   


}