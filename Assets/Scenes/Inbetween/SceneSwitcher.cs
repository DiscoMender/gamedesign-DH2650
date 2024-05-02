using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{

    [Serializable]
    public class customDictionary
    {
        public string GroupName;
        public string [] sceneNames;
    }

    [SerializeField]
    private customDictionary[] scenesGroups;

    [SerializeField]
    private string[] sceneNames;

    

    [SerializeField]
    private int sceneIndex = 0;
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Button button;


    private bool newSceneIsLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if no scene is loaded and the screen is clicked, load a random scene
        if (!newSceneIsLoaded && Input.GetMouseButtonDown(0))
        {

            LoadSequentialScene();
            newSceneIsLoaded = true;
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

    public void LoadRandomScene()
    {
        int randomIndex = UnityEngine.Random.Range(0, sceneNames.Length); // Generates a random index
        Debug.Log("Attempting to start " + sceneNames[randomIndex]);
        //StartCoroutine(LoadNewScene("Escaping"));
        StartCoroutine(LoadNewScene(sceneNames[randomIndex])); // Loads the scene at the random index
    }

    public void LoadSequentialScene() {
        StartCoroutine(LoadNewScene(sceneNames[sceneIndex])); // Loads the scene at the current index
        sceneIndex = (sceneIndex + 1) % sceneNames.Length; // Increments the index and wraps around if necessary
    }
}
