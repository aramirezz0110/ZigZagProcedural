using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text maxScoreText;

    [HideInInspector] public bool gameStarted;
    private int score;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateScoreInfo(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    private void UpdateScoreInfo(int value)
    {
        scoreText.text = "Score: " + value;
        maxScoreText.text = "Max score: " + GetHighScore();
    }
    public void StartGame()
    {
        gameStarted = true;
    }
    public void FinishGame()
    {
        SceneSwitcher.Instance.LoadMainScene();
    }
    public void IncreaseScore()
    {
        score ++;
        if (score > GetHighScore())
        {
            SetHighScore(score);
        }
        UpdateScoreInfo(score);
    }
    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreInfo(score);
    }
    public void ResetPlayerScore()
    {
        score = 0;
        UpdateScoreInfo(score);
    }
    private int GetHighScore()
    {
        return PlayerPrefs.GetInt(PlayerPrefsNames.Score, 0);
    }
    private void SetHighScore(int value)
    {
        PlayerPrefs.SetInt(PlayerPrefsNames.Score, value);
    }
}
