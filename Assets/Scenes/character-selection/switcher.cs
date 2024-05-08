using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickDetector : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private float clickTimeThreshold = 0.2f;
    private float clickTimer = 0f;

    void OnMouseDown()
    {
        startPosition = Input.mousePosition;
        clickTimer = 0f;
        isDragging = false;
    }

    void OnMouseDrag()
    {
        clickTimer += Time.deltaTime;

        if (!isDragging && Vector3.Distance(startPosition, Input.mousePosition) > 10f)
        {
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        if (!isDragging && clickTimer <= clickTimeThreshold)
        {
            Debug.Log("Click en: " + gameObject.name);
            bundle_selector.bundle = gameObject.name;
            PlayerStats.lives = PlayerStats.maxLives;
            PlayerStats.score = 0;
            SceneManager.LoadScene("InbetweenScene");
        }
    }
}
