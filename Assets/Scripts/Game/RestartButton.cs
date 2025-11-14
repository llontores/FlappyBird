using Zenject;

public class RestartButton : GameLauncher
{
    private GameOverScreen _gameOverScreen;

    [Inject]
    public void Construct(GameOverScreen gameOverScreen)
    {
        _gameOverScreen = gameOverScreen;
    }

    public void Restart()
    {
        _gameOverScreen.Close();
        StartGame();
    }
}