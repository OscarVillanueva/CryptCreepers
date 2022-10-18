using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Hacemos un singleton del GameManger
    public static GameManager Instance;

    public int time = 30;
    public int difficulty = 1;

    public bool gameOver = false;

    [SerializeField] int score;
    [SerializeField] AudioClip buttonClip;

    // Hacemos por medio de setters y getters
    public int Score
    {
        get => score;
        set
        {
            score = value;

            UIManager.Instance.UpdateUIScore(score);

            if (score % 1000 == 0) difficulty = difficulty + 1;
        }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.UpdateUITime(time);
        UIManager.Instance.UpdateUIScore(Score);
        StartCoroutine(CountDownRoutine());
    }

    public void PlayAgain()
    {
        AudioSource.PlayClipAtPoint(buttonClip, transform.position);
        Invoke(nameof(ReloadScene), 0.5f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator CountDownRoutine()
    {
        while (time > 0 && !gameOver)
        {
            yield return new WaitForSeconds(1);
            time = time - 1;
            UIManager.Instance.UpdateUITime(time);
        }

        gameOver = true;
        UIManager.Instance.ShowGameOverScreen();
    }

}
