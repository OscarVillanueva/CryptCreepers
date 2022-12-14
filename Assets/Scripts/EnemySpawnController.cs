using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    [SerializeField] GameObject[] enemyPreFab;
    [Range(0.1f, 10f)][SerializeField] float spawnRate = 1;


    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy()
    {
        while(!GameManager.Instance.gameOver)
        {
            yield return new WaitForSeconds(1/spawnRate);

            float random = Random.Range(0.0f, 1.0f);

            // 10% de probabilidad que salga el enemigo fuerte
            if (random < GameManager.Instance.difficulty * 0.1f) Instantiate(enemyPreFab[0]);
            else Instantiate(enemyPreFab[1]);
        }
    }
}
