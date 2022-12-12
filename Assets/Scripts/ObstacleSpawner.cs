using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject mazePrefab;
    public GameObject UFOPrefab;
    public GameObject nrgPrefab;
    public GameObject starShipPrefab;
    public Vector2Int size = new Vector2Int(10, 10);

    // Start is called before the first frame update
    void Start()
    {
        //spawnAsteroid();
        // spawn asteroid every 5 seconds
        // InvokeRepeating("spawnAsteroid", 1f, 10f);
        // InvokeRepeating("spawnMaze", 2f, 8f);
        InvokeRepeating("spawnUFO", 3f, 3f);
        InvokeRepeating("spawnNRG", 5f, 20f);
        // testSpawn();
        InvokeRepeating("spawnStarShip", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnAsteroid(){
        // spawn asteroid with random x position with
        // y position at top of screen
        //Instantiate(asteroidPrefab, new Vector3(randomX, 6f, 0), Quaternion.identity);
        //Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
    }

    void spawnMaze(){
        //Instantiate(mazePrefab, transform.position, Quaternion.identity);
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-5f, 5f);
        // Vertical Maze, 50/50 chance if it spawns from the bottom or top
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(mazePrefab, new Vector3(randomX, -6f, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(mazePrefab, new Vector3(randomX, 6f, 0), Quaternion.Euler(0, 0, 0));
        }
        //Instantiate(mazePrefab, new Vector3(randomX, 6f, 0), Quaternion.identity);
        // Horizontal Maze, 50/50 chance if it spawns from the left or right
        if (Random.Range(0, 2) == 0)
        {
           GameObject tiltMaze = Instantiate(mazePrefab, new Vector3(-10f, randomY, 0), Quaternion.Euler(0, 0, 90));
        }
        else
        {
           GameObject tiltMaze = Instantiate(mazePrefab, new Vector3(10f, randomY, 0), Quaternion.Euler(0, 0, 90));
        }
        // GameObject tiltMaze = Instantiate(mazePrefab, new Vector3(-10, randomY, 0), Quaternion.identity);
        // tiltMaze.transform.Rotate(0, 0, 90);
    }

    void spawnUFO(){
        // spawn UFO with random position outside of the screen
        // 50/50 chance if it spawns from the left or right
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(UFOPrefab, new Vector3(-10f, Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
        else
        {
            Instantiate(UFOPrefab, new Vector3(10f, Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
    }


    // spawn nrg with random position in the screen but not close to any obstacles
    void spawnNRG(){
        while(true){
            // spawn nrg with random position outside of the screen
            Vector2 randomPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-5f, 5f));
            // check if the random position is close to any obstacles
            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPos, 1f);
            // if there are no obstacles, spawn the nrg
            if (colliders.Length == 0){
                // spawn UFO and destroy the nrg after 10 seconds
                GameObject nrgRef = Instantiate(nrgPrefab, randomPos, Quaternion.identity);
                Destroy(nrgRef, 20f);

                break;
            }
        }
    }

    void spawnStarShip(){
        // if starship is already spawned, don't spawn another one
        if (GameObject.FindWithTag("StarShip") != null){
            return;
        }
        // spawn starship with random position outside of the screen
        // 25, 25, 25, 25 chance if it spawns from the left, right, top, bottom
        int random = Random.Range(0, 4);
        if (random == 0)
        {
            Instantiate(starShipPrefab, new Vector3(-10f, Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
        else if (random == 1)
        {
            Instantiate(starShipPrefab, new Vector3(10f, Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(starShipPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(starShipPrefab, new Vector3(Random.Range(-8f, 8f), -6f, 0), Quaternion.identity);
        }
    }

    void testSpawn(){
        Instantiate(nrgPrefab, new Vector3(5, 7, 0), Quaternion.identity);
    }

    

}
