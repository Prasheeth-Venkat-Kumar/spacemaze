using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on collision with an asteroid, stop this objects's parents movement
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            // stop the belt's parent's movement
           // transform.parent.setTargetPoint(transform.parent.position);
        }

        //Debug.Log("Lock asteroid position");
      //  transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
}
