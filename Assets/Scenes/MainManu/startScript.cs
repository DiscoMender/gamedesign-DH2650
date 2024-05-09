using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("character-selection");
    }
}
