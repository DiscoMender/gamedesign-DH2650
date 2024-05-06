using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancel_button : MonoBehaviour
{
    public GameObject background;
    public GameObject menu;
    public GameObject pause;
    public GameObject cancel;

    private void OnMouseDown()
    {
        Time.timeScale = 1;
        background.SetActive(false);
        menu.SetActive(false);
        pause.SetActive(true);
        cancel.SetActive(false);
    }
}
