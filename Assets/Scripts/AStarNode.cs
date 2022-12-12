using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents a node in the A* pathfinding grid
public class AStarNode
{
    // The position of this node in the grid
    public Vector2Int position;

    // The cost of moving to this node from the start node
    public int gCost;

    // The estimated cost of moving from this node to the end node
    public int hCost;

    // The total cost of moving to this node (gCost + hCost)
    public int fCost
    {
        get { return gCost + hCost; }
    }

    // The parent of this node in the path
    public AStarNode parent;

    // Constructor
    public AStarNode(Vector2Int pos, int g, int h, AStarNode p)
    {
        position = pos;
        gCost = g;
        hCost = h;
        parent = p;
    }
}
