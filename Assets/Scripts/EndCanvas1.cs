using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCanvas1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        
    public void handleQuitButton()
    {
        // quit the game
        Application.Quit();
    }



    public void handleReturnToStartButton()
    {
        // load the start scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
