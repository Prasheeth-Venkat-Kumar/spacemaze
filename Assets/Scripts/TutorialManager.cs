using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    private int currentStep = 0;

    //
    public TextMeshProUGUI infoBody;
    //
    public TextMeshProUGUI infoTitle;
    //
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    public void nextStep()
    {
        print("next step");
        currentStep++;
        if(currentStep == 1){
            infoTitle.text = "Mechanics";
            infoBody.text = "Use W to propel the ship forward, A and D to rotate the ship, and Click to fire.\n ";
        }
        else if(currentStep == 2){
            infoTitle.text = "Obstacles";
            infoBody.text = "A maze pattern will be generated and you must navigate through it to collect the NRG resource needed for your planet's survival. Be careful the maze will degrade over time and a new maze pattern will be created!\n ";
        }
        else if(currentStep == 3){
            infoTitle.text = "Enemies";
            infoBody.text = "UFOs will be generated and you must destroy them before they reach you. The UFO enemy will get smaller and smaller as they come closer to you!";

        }
        else if(currentStep == 4){
            infoTitle.text = "Good Luck!";
            infoBody.text = "Press the Next button to begin.";
        }
        else if (currentStep == 5){
            // load the sample scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
                
        }
    }
        

}
