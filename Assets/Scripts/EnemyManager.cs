using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] int health = 1;
    [SerializeField] float speed = 1;
    [SerializeField] int points = 100;
    [SerializeField] AudioClip impactClip;

    private Transform player;

    private void Start()
    {
        // Buscamos al jugador de manera dinamica
        PlayerManager manager = FindObjectOfType<PlayerManager>();
        if (manager) player = manager.transform;

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawPoint");
        int randowSpawnPoint = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randowSpawnPoint].transform.position;
        
    }

    private void Update()
    {

        if (player == null) return;

        // Obtenemos la dirección hacia el player
        Vector2 direction = player.position - transform.position;

        if (direction.x < 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (direction.x >= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Movemos el enemigo, normalizamos para que la magnitud del vector siempre sea la misma
        transform.position = transform.position + (Vector3)direction.normalized * Time.deltaTime * speed;

    }

    public void TakeDamage()
    {
        AudioSource.PlayClipAtPoint(impactClip, transform.position);

        health = health - 1;

        if (health <= 0)
        {
            GameManager.Instance.Score = GameManager.Instance.Score + points;
            Destroy(gameObject, 0.1f);
        }
    }

}
