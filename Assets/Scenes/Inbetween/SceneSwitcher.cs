using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        SceneData sceneData = new SceneData();
        
        StartCoroutine(LoadNewScene("Mini-golf"));
    
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
            
        //     StartCoroutine(LoadNewScene("FindTheKey"));
        // }
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

    public void returnToInbetween(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName); // Unloads the minigame scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("InbetweenScene")); // Sets the inbetween scene as the active scene
        canvas.gameObject.SetActive(true); // Enables the canvas to show the stats
    }

    [System.Serializable]
    public class SceneData
    {
        public int sceneBuildIndex;
        public string sceneKey;

        //public void LoadScene() //Maybe 
    }

    public List<SceneData> sceneDataList = new List<SceneData>();


}
