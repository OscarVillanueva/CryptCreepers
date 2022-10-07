using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Public solo puede ser accedido desde cualquier lugar
    // [SerializeField] solo accedido desde el inspector
    [SerializeField] float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] float fireRate = 1;

    //private int health = 10;
    private float horizontal;
    private float vertical;
    private Vector3 moveDirection;
    private Vector2 facingDirection;
    private bool isGunLoaded = true;

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        MoveAim();

        // si se preciona clic izquierdo
        if (Input.GetMouseButton(0) && isGunLoaded)
        {
            Shoot();
        }
    } 


    private void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection.x = horizontal;
        moveDirection.y = vertical;

        // Time.deltaTime es el tiempo que tarda en procesar entre frame y frame, varia entre las capacidades
        // entre más rápida la pc más pequeño el delta
        transform.position = transform.position + moveDirection * Time.deltaTime * speed;
    }

    private void MoveAim()
    {
        // Saca un punto de pantalla a espacio del mundo, pasar la posición del mouse/puntero al mundo
        // le restamos la dirección del mouse para moverlo de lugar <- aim p, p aim ->
        facingDirection = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //aim.position = transform.position + (Vector3)facingDirection.normalized;
        aim.position = transform.position + new Vector3(facingDirection.normalized.x, facingDirection.normalized.y, -0.01f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
             Destroy(gameObject);
        }
    }

    private void Shoot()
    {

        isGunLoaded = false;

        // obtenemos el angulo entre el jugador y la mira de radiandes a grados
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;

        // Sacamos la rotación
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Creamos la bala
        Instantiate(bulletPrefab, aim.position, targetRotation);

        StartCoroutine(ReloadGun());
    }

    // Despues de un segundo volvemos a dejar disparar
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        isGunLoaded = true;
    }
}
