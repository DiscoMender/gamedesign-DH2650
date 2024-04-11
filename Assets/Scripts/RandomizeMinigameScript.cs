using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class RandomizeMinigameScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SetIndices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRandomMinigame()
    {
        int randomIndex = Random.Range(0, sceneDataList.Count);
        SceneData scene = sceneDataList[randomIndex];
        SceneManager.LoadScene(scene.sceneBuildIndex);
    }


    [System.Serializable]
    public class SceneData
    {
        public int sceneBuildIndex;
        public string sceneKey;

        //public void LoadScene() //Maybe 
    }

    public List<SceneData> sceneDataList = new();

    public void SetIndices() {
        for (int i = 0; i < sceneDataList.Count; i++)
        {
            SceneData scene = GetSceneData(sceneDataList[i].sceneKey);
            scene.sceneBuildIndex = GetSceneIndex(i, scene.sceneKey);
        }
    }

    private int GetSceneIndex(int dataListIndex, string key) {
        SceneData scene = sceneDataList[dataListIndex];
        UnityEngine.SceneManagement.Scene unityScene = SceneManager.GetSceneByName(scene.sceneKey);
        return unityScene.buildIndex;
    }

    public SceneData GetSceneData(string key)
    {
        for (int i = 0; i < sceneDataList.Count; i++)
        {
            if (sceneDataList[i].sceneKey == key)
            {
                return sceneDataList[i];
            }
        }

        return null;
    }
}
