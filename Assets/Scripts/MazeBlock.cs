using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeBlock : MonoBehaviour
{
    private bool isBlinking = true;
    // var for animator
    private Animator animator;
    // lifespan of this is 30 seconds
    private float lifeSpan = 30.0f;
    //
    private int initBlinking = 3;


    // Start is called before the first frame update
    void Start()
    {
       // get animator
        animator = GetComponent<Animator>();
        // start blinking
        turnOnBlinking();
        // turn off blinking after 3 seconds
        Invoke("turnOffBlinking", initBlinking);
        // lock the position of this object
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        // Denegate after 30 seconds
        Invoke("Degenerate", lifeSpan);

    

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Degenerate(){
        // turn on blinking
        turnOnBlinking();
        // TODO: destroy this object after animation is complete
        Destroy(gameObject, 5);
    }

    void turnOffBlinking(){
        // Enable collider and rigidbody
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        isBlinking = false;
        animator.SetBool("isBlinking", isBlinking);
    }

    void turnOnBlinking(){
        // Disable collider and rigidbody
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        isBlinking = true;
        animator.SetBool("isBlinking", isBlinking);
    }


}
