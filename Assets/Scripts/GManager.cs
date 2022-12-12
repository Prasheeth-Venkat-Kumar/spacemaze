using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GManager : MonoBehaviour
{   

    public GameObject playerPrefab;

    public GameObject starShipPrefab;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nrgScoreText;

    public static int score = 0;
    public static int nrgScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPlayer();
        // spawnStarShip();
        // spawnUFO();
        score = 0;
        nrgScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        // if escape key is pressed, game over
        if (Input.GetKeyDown(KeyCode.Escape)){
            gameOver();
        }
    }

    void spawnPlayer(){
        // spawn player
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void spawnStarShip(){
        // spawn starship
        Instantiate(starShipPrefab, new Vector3(5, 10, 0), Quaternion.identity);
    }

    void updateScore(){
        // add to score as time goes on, increment animation
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void addNRGScore(){
        // update NRG score
        nrgScore += 1;
        nrgScoreText.text = "NRG: " + nrgScore;
    }

    public void gameOver(){
        // Move to GameOver scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }


}
