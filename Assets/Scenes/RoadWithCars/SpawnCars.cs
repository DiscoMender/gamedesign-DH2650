using UnityEngine;
using System.Collections;

public class Spawncars: MonoBehaviour
{
    public GameObject objectToSpawn; // El objeto que quieres instanciar
    public float spawnInterval = 1f; // Intervalo entre cada aparici�n en segundos
    public float minX = -5f; // L�mite m�nimo en el eje X
    public float maxX = 5f; // L�mite m�ximo en el eje X

    private void Start()
    {
        // Comienza la rutina para hacer aparecer objetos cada segundo
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Genera una posici�n aleatoria en el eje X dentro del rango especificado
            float randomX = Random.Range(minX, maxX);

            // Genera una posici�n justo arriba de la pantalla
            Vector3 spawnPosition = new Vector3(randomX, Camera.main.ViewportToWorldPoint(Vector3.up).y + 1f, 0f);

            // Instancia el objeto en la posici�n calculada
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Espera el intervalo de tiempo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
