using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxDelete : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Si el objeto se sale de la vista de la c�mara, lo destruye
        Destroy(gameObject);
    }
}
