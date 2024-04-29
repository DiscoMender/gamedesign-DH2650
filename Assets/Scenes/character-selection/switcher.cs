using System.Collections;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private float clickTimeThreshold = 0.2f;
    private float clickTimer = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            startPosition = Input.mousePosition; 
            clickTimer = 0f; 
            isDragging = false; 
        }
        else if (Input.GetMouseButton(0)) 
        {
            clickTimer += Time.deltaTime;

            if (!isDragging && Vector3.Distance(startPosition, Input.mousePosition) > 10f)
            {
                isDragging = true; // Se considera como arrastre si hay movimiento significativo
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Se levanta el botón del mouse
        {
            if (!isDragging && clickTimer <= clickTimeThreshold) // Si no hubo arrastre y el tiempo es menor al umbral
            {
                Debug.Log("Click!"); // Es un clic
            }
            else
            {
                Debug.Log("Drag or hold for " + clickTimer.ToString("F2") + " seconds"); // Es un arrastre o una pulsación prolongada
            }
        }
    }
}
