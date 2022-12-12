using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{   
    // get pathfinding object
    public AstarPath pathfinder;
    // re scan
    public int reScanTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        // get pathfinding script from gameobject
        pathfinder = GetComponent<AstarPath>();
        // re scan path
        InvokeRepeating("ReScanPath", 0, reScanTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReScanPath(){
        pathfinder.Scan();
    }
}
