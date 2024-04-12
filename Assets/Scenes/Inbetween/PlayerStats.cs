using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static double currentGameSpeed = 1; 

    public static int score = 0;
    public static int lives = 3;

    [SerializeField]
    private TextMeshProUGUI ScoreDisplay;
    [SerializeField]
    private TextMeshProUGUI LivesDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        ScoreDisplay.text = "Score: " + score.ToString();
        LivesDisplay.text = "Lives: " + lives.ToString();
    }

    private static void AddScore()
    {
        score++;
    }

    private static void RemoveScene(string sceneName)
    {
        // Tell the RandomizeMinigameScript to return to the inbetween scene
        GameObject.Find("SceneList").GetComponent<SceneSwitcher>().ReturnToInbetween(sceneName);     
        
    }

    /**
    * This method is called from a minigame scene when the player loses
    * It removes a life and removes the minigame scene
    * @param sceneName The name of the scene to remove
    */
    public static void LoseMinigame(string sceneName)
    {
        lives--;
        RemoveScene(sceneName);
    }

    /**
    * This method is called from a minigame scene when the player wins
    * It increases the score and removes the minigame scene
    * @param sceneName The name of the scene to remove
    */
    public static void WinMinigame(string sceneName)
    {
        AddScore();
        RemoveScene(sceneName);
    }
}
