using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaderbord : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
