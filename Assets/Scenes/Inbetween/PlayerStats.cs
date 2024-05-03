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
    private static int maxLives = 3;

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
        if (lives > 0) {
            LivesDisplay.text = "Lives: " + lives.ToString();
        }   
        else
        {
            LivesDisplay.text = "You lost all lives, game over!";
            
        }
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
        if (lives < 0) // TODO: Fix this awful hack
        {
            score = 0;
            lives = maxLives - 1;
        }
        RemoveScene(sceneName);
    }

    /**
    * This method is called from a minigame scene when the player wins
    * It increases the score and removes the minigame scene
    * @param sceneName The name of the scene to remove
    */
    public static void WinMinigame(string sceneName)
    {
        if (lives == 0) {  // TODO: Fix this awful hack
            score = 0;
            lives = maxLives;
        }
        AddScore();
        RemoveScene(sceneName);
    }

    public static void startPlaying()
    {
        RemoveScene("MainMenu");

    }
}
