using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_button_restart : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("character-selection");
    }
}
