using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarFollow : MonoBehaviour
{
    
    // The radius of the circle
    // public float cricleRadius = 20.0f;
    // The speed of the circle
    public int circleSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circleParent();
    }


    private void circleParent(){
        //  // Calculate the new position of the game object by moving it in a circle around its parent
        // Vector3 newPosition = transform.parent.position + (transform.parent.right * cricleRadius * Mathf.Sin(circleSpeed * Time.time)) + (transform.parent.up * cricleRadius * Mathf.Cos(circleSpeed * Time.time));

        // // Set the game object's position to the new position
        // transform.position = newPosition;

        // Rotate the game object around its parent
        transform.RotateAround(transform.parent.position, transform.parent.forward, circleSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet"){
            Destroy(gameObject);
        }
    }
}
