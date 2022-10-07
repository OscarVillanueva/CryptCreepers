using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Hacemos un singleton del GameManger
    public static GameManager Instance;

    [SerializeField] int time = 30;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        while ( time > 0)
        {
            yield return new WaitForSeconds(1);
            time = time - 1;
        }

        // Game over
    }

}
