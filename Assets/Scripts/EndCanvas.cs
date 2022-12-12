using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCanvas : MonoBehaviour
{
    //
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GManager.score + " NRG: X" + GManager.nrgScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handlePlayAgainButton()
    {
        // load sample scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void handleEndButton()
    {
        // load the start scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

}
