using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI ScoreDisplay;
    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = "Last score: " + PlayerStats.score;

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("character-selection");
        }
    }
}
