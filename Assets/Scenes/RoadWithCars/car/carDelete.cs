using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxDelete : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Si el objeto se sale de la vista de la cámara, lo destruye
        Destroy(gameObject);
    }
}
