using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField] float speed = 5;

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
            collision.GetComponent<EnemyManager>().TakeDamage();

        Destroy(gameObject);

    }
}
