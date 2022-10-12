using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    [SerializeField] int addedTime = 10;
    [SerializeField] AudioClip powerUpClip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(powerUpClip, transform.position);

            GameManager.Instance.time = GameManager.Instance.time + addedTime;
            Destroy(gameObject, 0.1f);
        }

    }

}
