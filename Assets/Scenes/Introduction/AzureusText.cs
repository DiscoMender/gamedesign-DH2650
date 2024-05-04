using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;


public class AzureusText : MonoBehaviour
{
    // Adjust typing speed
    public float typingSpeed = 0.05f;
    // The full text to be displayed
    public string fullText;
    // Text component to display text
    //private TMP_Text uiText;
    private Text uiText;
    // Current displayed text
    private string currentText = "";

    public AzureusIntro azureusIntro;

    public GameObject panel; // Reference to the panel GameObject


    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component
        uiText = GetComponent<Text> ();

        if (uiText == null)
        {
            Debug.LogError("Text component not found!");
            return;
        }

        panel.SetActive(false); // Hide the panel initially


        // Start the typing coroutine
        StartCoroutine(WaitForAzureus());
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
    IEnumerator WaitForAzureus()
    {
        yield return new WaitUntil(() => azureusIntro.azureusReached);

        // Show the panel once the character reaches the target
        panel.SetActive(true);

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Iterate through each character in the full text
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            uiText.text = currentText;
            // Wait for the specified typing speed before showing the next character
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
