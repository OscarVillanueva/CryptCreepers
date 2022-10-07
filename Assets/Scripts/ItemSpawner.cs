using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject checkpointPrefab;
    [SerializeField] int checkpointSpawnDelay = 10;
    [SerializeField] float spawnRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckpointRoutine());
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
}
