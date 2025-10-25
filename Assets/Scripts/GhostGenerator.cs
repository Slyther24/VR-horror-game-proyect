using System.Collections;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject ghostPrefab; // Prefab del fantasma
    public Vector3 spawnAreaMin; // Límite mínimo del área de aparición
    public Vector3 spawnAreaMax; // Límite máximo del área de aparición

    public Transform playerTransform; // Referencia al jugador
    private int currentSpawnRate = 1; // Tasa de aparición de fantasmas por segundo
    private float spawnInterval = 20f; // Intervalo entre apariciones
    private int initialSpawnCount = 1; // Número inicial de fantasmas
    private float timeElapsed = 0f; // Tiempo transcurrido desde el inicio de la aparición progresiva

    private void Start()
    {
        // Buscar al jugador en la escena por su tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Player' en la escena.");
        }

        // Generar los primeros 10 fantasmas al inicio
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnGhost();
        }

        // Iniciar la aparición progresiva de fantasmas
        StartCoroutine(SpawnGhostsOverTime());
    }

    private IEnumerator SpawnGhostsOverTime()
    {
        while (timeElapsed < 60f) // Limitar el aumento de la tasa hasta que pase 1 minuto
        {
            yield return new WaitForSeconds(spawnInterval);

            // Genera el número actual de fantasmas según la tasa de aparición
            for (int i = 0; i < currentSpawnRate; i++)
            {
                SpawnGhost();
            }

            timeElapsed += spawnInterval;

            // Incrementar la tasa de aparición cada 10 segundos
            if (timeElapsed % 2 == 0 && currentSpawnRate < 6)
            {
                currentSpawnRate++; // Incrementa la cantidad de fantasmas que aparecen por cada segundo
            }
        }
    }

    private void SpawnGhost()
    {
        // Genera una posición aleatoria dentro del área de aparición
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Crea el fantasma con la rotación inicial deseada (-90 en X)
        Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
        GameObject ghost = Instantiate(ghostPrefab, spawnPosition, spawnRotation);

        // Asigna el objetivo del jugador al fantasma
        if (playerTransform != null)
        {
            ghost.GetComponent<GhostController>().SetTarget(playerTransform);
        }
    }
}









