using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    private float size;
    private float speed;
    private Vector3 targetPoint;
    private float timeToLive;

    void Awake()
    {
        targetPoint = generateRandomPoint();
        // set speed
        speed = Random.Range(0.5f, 1f);
        // set size
        size = Random.Range(0.1f, 0.5f);
        transform.localScale = new Vector3(size, size, 1);
        // set time to live
        timeToLive = Random.Range(30f, 60f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
    }

    Vector3 generateRandomPoint(){
        //generate random position on the screen
        Vector3 randomPoint = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
        return randomPoint;
    }

    // setter method for target point
    public void setTargetPoint(Vector3 targetPoint){
        this.targetPoint = targetPoint;
    }




   

   
}
