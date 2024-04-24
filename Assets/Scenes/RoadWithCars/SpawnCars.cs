using UnityEngine;
using System.Collections;

public class Spawncars: MonoBehaviour
{
    public GameObject objectToSpawn; // El objeto que quieres instanciar
    public float spawnInterval = 1f; // Intervalo entre cada aparición en segundos
    public float minX = -5f; // Límite mínimo en el eje X
    public float maxX = 5f; // Límite máximo en el eje X

    private void Start()
    {
        // Comienza la rutina para hacer aparecer objetos cada segundo
        StartCoroutine(SpawnObjectRoutine());
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Genera una posición aleatoria en el eje X dentro del rango especificado
            float randomX = Random.Range(minX, maxX);

            // Genera una posición justo arriba de la pantalla
            Vector3 spawnPosition = new Vector3(randomX, Camera.main.ViewportToWorldPoint(Vector3.up).y + 1f, 0f);

            // Instancia el objeto en la posición calculada
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Espera el intervalo de tiempo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
