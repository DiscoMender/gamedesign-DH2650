using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    public float remainingSeconds = 20f;
    public bool isTimeRunning;
  
    void Start()
    {
        isTimeRunning = true;
        remainingSeconds += 1;
    }

    void Update()
    {
        if (isTimeRunning)
        {
            remainingSeconds -= Time.deltaTime;
            if (remainingSeconds > 0)
            {
                DisplayTime(remainingSeconds);
            }
            else
            {
                remainingSeconds = 0;
                //gameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
