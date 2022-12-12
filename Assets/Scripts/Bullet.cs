using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private float speed = 100f;
    private Rigidbody2D rb;
    private float timeToLive = 10f;

    public bool isBad = false;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootBullet(Vector2 direction, bool isBad)
    {
        // if bad, set color to red
        if(isBad)
        {
            this.isBad = true;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
         // rorate the bullet to face the direction it is moving
        transform.up = direction;
        rb.AddForce(direction * speed);
        Destroy(gameObject, timeToLive);
    }
    // trigger collision with enemy
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // if(collision.gameObject.tag == "Maze")
    //     // {
    //     //     Destroy(gameObject);
    //     // }
    //     if(collision.gameObject.tag == "UFO")
    //     {
    //         collision.gameObject.GetComponent<UFO>().animateAndDestroy();
    //         Destroy(gameObject);
    //     }
    //     else if(collision.gameObject.tag == "StarShip")
    //     {
    //         // collision.gameObject.GetComponent<SSPlayerScript>().animateAndDestroy();
    //         // Destroy(gameObject);
    //     }
    //     else if (collision.gameObject.tag == "Maze")
    //     {
    //         // Destroy(gameObject);
    //     }

    // }

    // if bullet collides with maze or an another bullet, destroy bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Maze" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
