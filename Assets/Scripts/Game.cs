using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemiesSpawner _spawner;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartScreen _startScreen;
    public bool IsActive { get; private set; }

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
    }

    private void Start()
    {
        IsActive = false;
        Time.timeScale = 0;
        _gameOverScreen.Close();
        _startScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _spawner.ResetPool();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }
    private void StartGame()
    {
        IsActive = true;
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    private void OnGameOver()
    {
        IsActive = false;
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
    