using Zenject;

public class PlayButton : GameLauncher
{
    private StartScreen _startScreen;

    [Inject]
    public void Construct(StartScreen startScreen)
    {
        _startScreen = startScreen;
    }

    public void Play()
    {
        _startScreen.Close();
        StartGame();
    }
}