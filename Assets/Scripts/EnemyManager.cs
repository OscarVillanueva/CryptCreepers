using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] int health = 1;
    [SerializeField] float speed = 1;

    private Transform player;

    private void Start()
    {
        // Buscamos al jugador de manera dinamica
        player = FindObjectOfType<PlayerManager>().transform;
    }

    private void Update()
    {

        if (player == null) return;

        // Obtenemos la dirección hacia el player
        Vector2 direction = player.position - transform.position;

        // Movemos el enemigo
        transform.position = transform.position + (Vector3)direction.normalized * Time.deltaTime * speed;

    }

    public void TakeDamage()
    {
        health = health - 1;

        if (health >= 0) Destroy(gameObject);
    }

}
