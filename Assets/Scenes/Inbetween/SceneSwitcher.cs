using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{

    [Serializable]
    public class CustomDictionary
    {
        public string GroupName;
        public string [] sceneNames;
    }

    [SerializeField]
    private CustomDictionary[] scenesGroups;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Button button;

    private int sceneIndex = 0;

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

            //LoadSequentialScene();
            LoadScene(false);
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

    public void LoadScene(bool debug = false)
    {
        CustomDictionary group = Array.Find(scenesGroups, x => x.GroupName == bundle_selector.bundle);
        if (!debug)
        {
            int randomIndex = UnityEngine.Random.Range(0, group.sceneNames.Length);
            Debug.Log("Attempting to start " + group.sceneNames[randomIndex]);
            StartCoroutine(LoadNewScene(group.sceneNames[randomIndex]));
        }
        else
        {
            StartCoroutine(LoadNewScene(group.sceneNames[sceneIndex])); // Loads the scene at the current index
            sceneIndex = (sceneIndex + 1) % group.sceneNames.Length; // Increments the index and wraps around if necessary
        }
        
    }
}
