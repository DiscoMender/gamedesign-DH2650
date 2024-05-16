using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneSwitcher : MonoBehaviour
{

    [Serializable]
    public class CustomDictionary
    {
        public string GroupName;
        public string [] sceneNames;
    }

    [Serializable]
    public class CustomDictionaryHelpText
    {
        public string Name;
        public string text;
    }

    [SerializeField]
    private CustomDictionary[] scenesGroups;

    [SerializeField]
    private CustomDictionaryHelpText[] HelpTexts;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Button button;

    private int sceneIndex = 0;

    private bool newSceneIsLoaded = false;
    private bool sceneHelpTextIsBeingShown = false;

    [SerializeField]
    private GameObject ScoreScreenTextObjects;

    [SerializeField] 
    private GameObject helpTextObject;
    [SerializeField]
    private TextMeshProUGUI helpText;

    private string helpTextDefaultString = "Get ready for the next minigame!";
    [SerializeField]
    private float sceneHelpTextTime = 3.0f;
    private float sceneHelpTextTimer = 0.0f;

    private int nextSceneIndex = 0;

    private CustomDictionary group;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        // if no scene is loaded and the screen is clicked, load the help text for the next scene
        if (!newSceneIsLoaded && Input.GetMouseButtonDown(0) && !sceneHelpTextIsBeingShown)
        {
            sceneHelpTextIsBeingShown = true;
            sceneHelpTextTimer = sceneHelpTextTime; // Reset the timer for the help text

            // Generate the next scene index
            group = Array.Find(scenesGroups, x => x.GroupName == bundle_selector.bundle);
            nextSceneIndex = UnityEngine.Random.Range(0, group.sceneNames.Length);

            // TODO: load the help text for the next scene
            String gameName = group.sceneNames[nextSceneIndex];

            ScoreScreenTextObjects.SetActive(false);
            helpTextObject.SetActive(true);

            // set the help text
            String text = Array.Find(HelpTexts, x => x.Name == gameName).text;
            helpText.text = text;

            return;

        }

        if (sceneHelpTextIsBeingShown) {
            sceneHelpTextTimer -= Time.deltaTime; 
            if (sceneHelpTextTimer <= 0.0f || Input.GetMouseButtonDown(0)) {  // If the timer is up, hide the help text and load the scene
                sceneHelpTextIsBeingShown = false;
                sceneHelpTextTimer = 0.0f;
                // TODO: hide the help text for the next scene
                helpTextObject.SetActive(false);
                ScoreScreenTextObjects.SetActive(true);


                // Load the new scene
                if (PlayerStats.lives <= 0)
                {
                    StartCoroutine(LoadNewScene("mainMenu"));
                }
                else
                {
                    //LoadSequentialScene();
                    LoadScene(false);
                    newSceneIsLoaded = true;
                }
            }
        }
    }

    IEnumerator LoadNewScene(string sceneName)
    {


        var parameters = new LoadSceneParameters(LoadSceneMode.Additive); // Ensures that the scene is loaded additively
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, parameters);


        while (!asyncLoad.isDone) // Waits until the scene is loaded
        {
            yield return null;
        }

        canvas.gameObject.SetActive(false); // Disables the canvas to hide the stats

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName)); // Sets the scene as the active scene
    }

    public void ReturnToInbetween(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName); // Unloads the minigame scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("InbetweenScene")); // Sets the inbetween scene as the active scene
        canvas.gameObject.SetActive(true); // Enables the canvas to show the stats
        newSceneIsLoaded = false; // Resets the newSceneIsLoaded variable
    }
    

    public void LoadScene(bool debug = false)
    {
        if (!debug)
        {
            Debug.Log("Attempting to start " + group.sceneNames[nextSceneIndex]);
            StartCoroutine(LoadNewScene(group.sceneNames[nextSceneIndex]));
        }
        else
        {
            StartCoroutine(LoadNewScene(group.sceneNames[sceneIndex])); // Loads the scene at the current index
            sceneIndex = (sceneIndex + 1) % group.sceneNames.Length; // Increments the index and wraps around if necessary
        }
        
    }
}
