using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_button_main : MonoBehaviour
{
    private void OnMouseDown()
    {
        controller.isPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
