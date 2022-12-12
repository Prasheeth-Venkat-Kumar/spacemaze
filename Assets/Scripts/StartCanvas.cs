using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCanvas : MonoBehaviour
{

    public float typingSpeed = 0.1f; // The speed at which each character is typed (in seconds)
    private string currentText = ""; // The text that has been typed so far
    private string targetText; // The full text to be typed
    private bool isTyping = false; // Whether the animation is currently running
    [SerializeField] private TextMeshProUGUI txtStart; // The text component that will display the text


    // Start is called before the first frame update
    void Start()
    {
        StartTyping("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        // if the animation is done wait 1 sec, start the animation again
        if (!isTyping)
        {
            StartTyping("Start!");
        }
    }

    
    public void StartTyping(string text)
    {
        // Set the text to be typed and reset the current text
        targetText = text;
        currentText = "";

        // Start the coroutine
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;

        // Type each character of the target text one at a time
        foreach (char c in targetText)
        {
            currentText += c;
            // get the txtStart component and set the text to the current text
            txtStart.text = currentText;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void handleStartButton()
    {
        // load tutorial scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }





}
