using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeSpawner _spawner;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartScreen _startScreen;

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
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
    