using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image scoreScreen;
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private AudioClip gameOverClip;

    private Camera newCamera;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        newCamera = FindObjectOfType<Camera>();
    }

    public void UpdateUIScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    public void UpdateUIHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void UpdateUITime(int newTime)
    {
        timeText.text = newTime.ToString();
    }

    public void ShowGameOverScreen()
    {

        newCamera.GetComponent<AudioSource>().Stop();        
        AudioSource.PlayClipAtPoint(gameOverClip, transform.position);

        gameOverScreen.SetActive(true);

        finalScore.text = GameManager.Instance.Score + "";
    }
}
