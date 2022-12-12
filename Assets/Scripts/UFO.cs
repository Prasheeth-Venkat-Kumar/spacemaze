using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UFO : MonoBehaviour
{
    private GameObject player;
    private float timeToLive = 20f;
    private float size;
    private float speed;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;


    // Start is called before the first frame update
    void Start()
    {
        // find the player object wtih the tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        speed = Random.Range(0.5f, 1f);

        // Destroy(gameObject, timeToLive);

        Invoke("animateAndDestroy", timeToLive);

        // new code
        seeker = GetComponent<Seeker>();
        //
        InvokeRepeating("generatePath", 0f, 0.5f);


    }

    void generatePath(){
        // generate path
        seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
    }

    void OnPathComplete(Path p){
        // if path is not valid, return
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if path is not null, move towards the player
        if (path == null){
              return;
        }

        if (currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        // move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, path.vectorPath[currentWaypoint], speed * Time.deltaTime);

        // if the distance between the current waypoint and the player is less than 0.1, move to the next waypoint
        if (Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]) < 0.1f){
            currentWaypoint++;
        }

    }

    // // on trigger collision with any object, destroy the UFO
    void OnTriggerEnter2D(Collider2D other){
        //
        // print("UFO hit something");
        // trigger the expo animation
        GetComponent<Animator>().SetTrigger("expo");
        // destroy the UFO after the animation is done
        Destroy(gameObject, 0.6f);
    }

    public void animateAndDestroy(){
        // trigger the expo animation
        GetComponent<Animator>().SetTrigger("expo");
        // destroy the UFO after the animation is done
        Destroy(gameObject, 0.6f);
    }


  


}





