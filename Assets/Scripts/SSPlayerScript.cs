using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSPlayerScript : MonoBehaviour
{
    //fields
    private bool thrust = false;
    private float thrustDirection = 0f;
    private float thrustSpeed = 0.2f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // find the game manager object wtih the tag "Manager"
        gameManager = GameObject.FindGameObjectWithTag("Manager");

    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
         // shoot bullet if mouse is clicked or spacebar is pressed
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }


    void handleMovement(){
        // check for WASD input
        // if WASD input, move in that direction
        // if no WASD input, move in a random direction
        thrust = Input.GetKey(KeyCode.W);

        if (Input.GetKey(KeyCode.D))
        {
            thrustDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            thrustDirection = 1f;
        }
        else
        {
            thrustDirection = 0f;
        }
    }

    private void FixedUpdate()
    {
       
        if (thrust)
        {
            rb.AddForce(transform.up * thrustSpeed);
        }
        //Debug.Log("thrustDirection: " + thrustDirection);
        if(thrustDirection != 0f)
        {
            rb.AddTorque(thrustDirection * thrustSpeed);
        }
        
    }

    public void shoot()
    {   // spawn the bullet in front of the player
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up * 0.3f, Quaternion.identity);
        bullet.GetComponent<Bullet>().shootBullet(transform.up, false);
        Debug.Log("shootBullet");
    }

    // Trigger collision with Maze
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Maze")
        {
            // push the player away from the maze
            rb.AddForce(transform.up * -thrustSpeed);
        }
    }

    // collision 2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "UFO")
        {
            // call the enemy's animation and destroy method
            collision.gameObject.GetComponent<UFO>().animateAndDestroy();
            // call the game manager's game over method
            gameManager.GetComponent<GManager>().gameOver();
        }
        else if(collision.gameObject.tag == "Bullet"){
            if (collision.gameObject.GetComponent<Bullet>().isBad)
            {
                // call the game manager's game over method
                gameManager.GetComponent<GManager>().gameOver();
            }
        }
        else if(collision.gameObject.tag == "StarShip")
        {
            // call the game manager's game over method
            gameManager.GetComponent<GManager>().gameOver();
        }
        else if (collision.gameObject.tag == "nrg")
        {
           // destroy the nrg
           Destroy(collision.gameObject);
           // call the game manager's update nrg method
            gameManager.GetComponent<GManager>().addNRGScore();
        }

    }
        // else if(collision.gameObject.tag == "Maze")
        // {
        //     // push the player away from the maze
        //     rb.AddForce(transform.up * -thrustSpeed);
        // }
    
}
