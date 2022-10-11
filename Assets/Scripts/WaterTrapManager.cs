using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrapManager : MonoBehaviour
{
    [SerializeField] private float speedReductionRatio = 0.5f;

    private PlayerManager player;
    private float originalSpeed;
    
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        if (player) originalSpeed = player.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            player.speed = player.speed * speedReductionRatio;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Cuando el player salga del charco se regresa a su velocidad original
        if (collision.CompareTag("Player"))
        {
            player.speed = originalSpeed;
        }
    }
}
