using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StarShip : MonoBehaviour
{

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;

    private GameObject target;
    private GameObject player;
    public GameObject bulletPrefab;
    private float speed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        // set target to tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        // if no player, destroy self
        if (player == null)
        {
            Destroy(gameObject);
        }
        // set target to tag "Player"
        target = player;
        // new code
        seeker = GetComponent<Seeker>();
       
        InvokeRepeating("generatePath", 1f, 0.5f);
        pickTarget();
        if(target == player)
        {
            InvokeRepeating("checkAndShoot", 1f, 2f);
        }
        

    }

    void generatePath(){
        if(target == null){
            return;
        }
        // generate path
        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
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
        // anytime nrg doesn't exist, set target to player
        if(GameObject.FindGameObjectWithTag("nrg") == null){
            target = player;
            InvokeRepeating("checkAndShoot", 1f, 2f);
        }
        // look at the direction of the target
        transform.up = target.transform.position - transform.position;
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


    public void shoot()
    {   // spawn the bullet in front of the player
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up * 0.3f, Quaternion.identity);
        bullet.GetComponent<Bullet>().shootBullet(transform.up, true);
        // Debug.Log("shootBullet");
    }
 
    private void checkAndShoot(){
        // Raycast from the starship to the player, don't hit the starship itself
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, 100f);
 
        // check if 2 element of array exists
        if (hits.Length > 1)
        {
            // check if the second element is the player
            if (hits[1].collider.gameObject.tag == "Player")
            {
                shoot();
            }
        }
    }

    private void pickTarget(){
    // var to store the distance between the starship and the nrg
    float distance = 0;
    // var to store the distance between the starship and the player
    float distance2 = 0;
    // find nrg gameobject
    GameObject nrg = GameObject.FindGameObjectWithTag("nrg");
    // if nrg exists, set target to nrg
    if(nrg != null){
        distance = Vector3.Distance(nrg.transform.position, transform.position);
    }
    else{
        target = player;
        return;
    }

    if(player != null){
        distance2 = Vector3.Distance(player.transform.position, transform.position);
    }
    // if nrg is closer than the player, set target to nrg
    if(distance < distance2){
        target = nrg;
    }else{
        target = player;
    }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the startsip collides with bullet, destroy the bullet and the starship
        if (collision.gameObject.tag == "Bullet") 
        {
            // if the bullet is from the player, destroy the starship
            if (collision.gameObject.GetComponent<Bullet>().isBad == false)
            {
                print("got hit by player bullet");
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "nrg")
        {
           // destroy the nrg
           Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Maze")
        {
            // destroy the player
            Destroy(gameObject);
        }
    }
   

  




}
