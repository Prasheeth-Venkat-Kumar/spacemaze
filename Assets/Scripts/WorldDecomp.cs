// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WorldDecomp : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }


//     // This function converts a world position to the corresponding position in the array
//     private Vector2Int WorldToArrayPosition(Vector3 worldPosition, int gridSizeX, int gridSizeY)
//     {
//         // Calculate the array position by dividing the world position by the size of each cell
//         int arrayPosX = Mathf.FloorToInt(worldPosition.x / cellSize);
//         int arrayPosY = Mathf.FloorToInt(worldPosition.z / cellSize);

//         // Ensure that the array position is within the bounds of the array
//         arrayPosX = Mathf.Clamp(arrayPosX, 0, gridSizeX - 1);
//         arrayPosY = Mathf.Clamp(arrayPosY, 0, gridSizeY - 1);

//         // Return the array position as a Vector2Int
//         return new Vector2Int(arrayPosX, arrayPosY);
//     }
// }



