using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject background;
    public GameObject menu;
    public GameObject pause;
    public GameObject cancel;
    public GameObject canvas;

    private void Start()
    {
        background.SetActive(false);
    }

    private void OnMouseDown()
    {
        controller.isPause = true;
        Time.timeScale = 0;
        background.SetActive(true);
        menu.SetActive(true);
        pause.SetActive(false);
        cancel.SetActive(true);
        canvas.SetActive(true);
    }
}

