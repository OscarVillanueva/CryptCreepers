using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Hacemos un singleton del GameManger
    public static GameManager Instance;

    public int time = 30;
    public int difficulty = 1;

    [SerializeField] int score; 

    // Hacemos por medio de setters y getters
    public int Score
    {
        get => score;
        set
        {
            score = value;
            if (score % 1000 == 0) difficulty = difficulty + 1;
        }
    }

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
