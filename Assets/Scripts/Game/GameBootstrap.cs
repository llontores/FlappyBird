using System;
using UnityEngine;
using Zenject;

public class GameBootstrap : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly StartScreen _startScreen;
    private readonly PlayButton _gameStart;
    private readonly RestartButton _gameRestart;
    private readonly GameOverHandler _gameOver;
    private readonly GameOverScreen _gameOverScreen;

    public GameBootstrap(SignalBus signalBus, StartScreen startScreen, 
        PlayButton gameStart, RestartButton gameRestart,
        GameOverHandler gameOver, GameOverScreen gameOverScreen)
    {
        _signalBus = signalBus;
        _startScreen = startScreen;
        _gameStart = gameStart;
        _gameRestart = gameRestart;
        _gameOver = gameOver;
        _gameOverScreen = gameOverScreen;
    }

    public void Initialize()
    {
        Time.timeScale = 0;
        _gameOverScreen.Close();
        _startScreen.Open();
        
        _signalBus.Subscribe<GameOverSignal>(_gameOver.Handle);
        _signalBus.Subscribe<PlayButtonClickedSignal>(_gameStart.Play);
        _signalBus.Subscribe<RestartButtonClickedSignal>(_gameRestart.Restart);
    }

    public void Dispose()
    {
       _signalBus.Unsubscribe<GameOverSignal>(_gameOver.Handle);
       _signalBus.Unsubscribe<PlayButtonClickedSignal>(_gameStart.Play);
       _signalBus.Unsubscribe<RestartButtonClickedSignal>(_gameRestart.Restart);
    }
}