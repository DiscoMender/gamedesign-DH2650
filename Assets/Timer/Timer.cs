using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] public float remainingSeconds = 20f;
    public bool isTimeRunning;
    public static bool isCountDown = true;
    private bool isBlinking = false;
    private bool isFirstTime = true;
    private float inicialTime;

    void Start()
    {
        isTimeRunning = true;
        //remainingSeconds += 1;
        inicialTime = remainingSeconds;
    }

    void Update()
    {
        if (remainingSeconds <= 0)
        {
            isTimeRunning = false;
        }

        if (isTimeRunning)
        {
            if (remainingSeconds < (inicialTime * 0.6) && remainingSeconds > (inicialTime * 0.4))
            {
                timer.color = new Color(255, 255, 0, 255); // Yellow
                isBlinking = false;
            }
            else if (remainingSeconds <= (inicialTime * 0.4))
            {
                isBlinking = true;
                //StartCoroutine(BlinkText());
            }
            DisplayTime(remainingSeconds);
          
            if (isBlinking && isFirstTime)
            {
                StartCoroutine(BlinkText());
                isFirstTime = false;
            }
        }

        remainingSeconds -= Time.deltaTime;
    }

    IEnumerator BlinkText()
    {
        while (isBlinking)
        {
            timer.color = new Color(255, 0, 0, 255); // Red
            yield return new WaitForSeconds(0.5f);
            timer.color = new Color(255, 255, 255, 100); // White
            yield return new WaitForSeconds(0.5f);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}


