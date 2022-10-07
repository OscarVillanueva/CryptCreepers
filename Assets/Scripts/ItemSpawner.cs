using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int checkpointSpawnDelay = 10;
    [SerializeField] int powerUpSpawnDelay = 12;
    [SerializeField] float spawnRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
        StartCoroutine(SpawnPowerUpRoutine());

    }

    IEnumerator SpawnCheckpointRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkpointSpawnDelay);

            // Apartir del spawner tener un radio de 5 para generar 
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnDelay);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            int random = Random.Range(0, powerUpPrefab.Length);

            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);

        }
    }
}
