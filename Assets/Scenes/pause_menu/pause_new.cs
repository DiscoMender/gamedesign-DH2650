using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton_new : MonoBehaviour
{
    
    public GameObject menu;
    public GameObject pause;
    public GameObject canvas;
    public GameObject timer;


    private void OnMouseDown()
    {
        controller.isPause = true;
        Time.timeScale = 0;
        pause.SetActive(false);
        timer.SetActive(false);
        menu.SetActive(true);
        canvas.SetActive(true);
    }
}

