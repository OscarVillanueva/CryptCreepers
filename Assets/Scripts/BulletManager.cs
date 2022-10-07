using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField] float speed = 5;
    [SerializeField] int health = 3;

    public bool isPowerShot = false;

    private void Start()
    {
        // Auto destruirse despues de 5 segundos
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position = transform.position + transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Decimos al enemigo que redusca su vida.
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyManager>().TakeDamage();

        }

        health = health - 1;

        if (!isPowerShot || health <= 0)
            Destroy(gameObject);

    }
}
