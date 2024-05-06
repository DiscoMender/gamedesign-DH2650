using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject background;
    public GameObject menu;
    public GameObject pause;
    public GameObject cancel;

    private void Start()
    {
        background.SetActive(false);
    }

    private void OnMouseDown()
    {
        Time.timeScale = 0;
        background.SetActive(true);
        menu.SetActive(true);
        pause.SetActive(false);
        cancel.SetActive(true);
    }
}

