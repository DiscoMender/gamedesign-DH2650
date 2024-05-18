using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancel_new : MonoBehaviour
{
    public GameObject menu;
    public GameObject pause;
    public GameObject canvas;
    public GameObject timer;

    private void OnMouseDown()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pause.SetActive(true);
        canvas.SetActive(false);
        timer.SetActive(true);
        Invoke("UnpauseDelayed", 0.2f);
    }

    private void UnpauseDelayed()
    {
        controller.isPause = false;
    }
}