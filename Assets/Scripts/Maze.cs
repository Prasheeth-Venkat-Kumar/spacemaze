// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Maze : MonoBehaviour
// {
//     private float size;
//     private float speed;
//     private Vector3 targetPoint;
//     private float timeToLive;
//     private bool moveLock = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         targetPoint = generateRandomPoint();
//         // set speed
//         speed = Random.Range(0.5f, 1f);
//         // set size
//         // size = Random.Range(0.1f, 0.5f);
//         // transform.localScale = new Vector3(size, size, 1);
//         // set roation to 0 or 90 depending on a 50/50 chance
//         // if (Random.Range(0, 2) == 0)
//         // {
//         //     transform.rotation = Quaternion.Euler(0, 0, 0);
//         // }
//         // else
//         // {
//         //     transform.rotation = Quaternion.Euler(0, 0, 90);
//         // }
//         // set time to live
//         timeToLive = Random.Range(30f, 40f);
//         // Deteriating Maze
//         Destroy(gameObject, timeToLive);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(!moveLock){
//             float step = speed * Time.deltaTime;
//             transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
//         }
    
//     }

    
//     Vector3 generateRandomPoint(){
//         //generate random position on the screen
//         Vector3 randomPoint = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
//         return randomPoint;
//     }

//     // set move lock
//     public void setMoveLock(bool moveLock){
//         this.moveLock = moveLock;
//     }


 
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.tag == "Maze")
//         {
//             // if the maze object is above the player screen, destroy it
//             if(transform.position.y > 6 || transform.position.y < -6){
//                 Destroy(gameObject);
//             }
//             else if(transform.position.x > 9 || transform.position.x < -9){
//                 Destroy(gameObject);
//             }
//             else{
//                 setMoveLock(true);
//             }
//         }
//     }



//     // titl the maze object
//     public void tilt(){
//         transform.rotation = Quaternion.Euler(0, 0, 90);
//     }


// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Maze : MonoBehaviour
// {
//     private float size;
//     private float speed;
//     private Vector3 targetPoint;
//     private float timeToLive;
//     private bool moveLock = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         targetPoint = generateRandomPoint();
//         // set speed
//         speed = Random.Range(0.5f, 1f);
//         // set size
//         // size = Random.Range(0.1f, 0.5f);
//         // transform.localScale = new Vector3(size, size, 1);
//         // set roation to 0 or 90 depending on a 50/50 chance
//         // if (Random.Range(0, 2) == 0)
//         // {
//         //     transform.rotation = Quaternion.Euler(0, 0, 0);
//         // }
//         // else
//         // {
//         //     transform.rotation = Quaternion.Euler(0, 0, 90);
//         // }
//         // set time to live
//         timeToLive = Random.Range(30f, 40f);
//         // Deteriating Maze
//         Destroy(gameObject, timeToLive);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(!moveLock){
//             float step = speed * Time.deltaTime;
//             transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
//         }
    
//     }

    
//     Vector3 generateRandomPoint(){
//         //generate random position on the screen
//         Vector3 randomPoint = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
//         return randomPoint;
//     }

//     // set move lock
//     public void setMoveLock(bool moveLock){
//         this.moveLock = moveLock;
//     }


 
//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.tag == "Maze")
//         {
//             // if the maze object is above the player screen, destroy it
//             if(transform.position.y > 6 || transform.position.y < -6){
//                 Destroy(gameObject);
//             }
//             else if(transform.position.x > 9 || transform.position.x < -9){
//                 Destroy(gameObject);
//             }
//             else{
//                 setMoveLock(true);
//             }
//         }
//     }



//     // titl the maze object
//     public void tilt(){
//         transform.rotation = Quaternion.Euler(0, 0, 90);
//     }


// }



