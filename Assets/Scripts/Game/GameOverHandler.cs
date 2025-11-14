using UnityEngine;

public class GameOverHandler
{
    private readonly PipeSpawner _spawner;
    private readonly GameOverScreen _gameOverScreen;

    public GameOverHandler(PipeSpawner spawner, GameOverScreen gameOverScreen)
    {
        _spawner = spawner;
        _gameOverScreen = gameOverScreen;
    }

    public void Handle()
    {
        Time.timeScale = 0;
        _spawner.StopSpawning();
        _gameOverScreen.Open();
    }
}