using System;
using UnityEngine;
using Zenject;

public class Game : IInitializable, IDisposable
{
    private Bird _bird;
    private PipeSpawner _spawner;
    private GameOverScreen _gameOverScreen;
    private StartScreen _startScreen;
    private SignalBus _signalBus;

    [Inject]
    public void Construct(Bird bird, PipeSpawner spawner, GameOverScreen gameOverScreen, StartScreen startScreen, SignalBus signalBus)
    {
        _bird = bird;
        _spawner = spawner;
        _gameOverScreen = gameOverScreen;
        _startScreen = startScreen;
        _signalBus = signalBus;
    }


    public void Initialize()
    {
        _signalBus.Subscribe<GameOverSignal>(OnGameOver);
        _signalBus.Subscribe<RestartButtonClickedSignal>(OnRestartButtonClick);
        _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClick);
        
        Time.timeScale = 0;
        _gameOverScreen.Close();
        _startScreen.Open();
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<GameOverSignal>(OnGameOver);
        _signalBus.Unsubscribe<RestartButtonClickedSignal>(OnRestartButtonClick);
        _signalBus.Unsubscribe<PlayButtonClickedSignal>(OnPlayButtonClick);
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
    