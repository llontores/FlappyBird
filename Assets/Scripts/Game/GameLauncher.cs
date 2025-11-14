using UnityEngine;
using Zenject;

public class GameLauncher
{
    private PipeSpawner _spawner;
    private Bird _bird;

    [Inject]
    public void Construct(PipeSpawner spawner, Bird bird)
    {
        _spawner = spawner;
        _bird = bird;
    }

    protected void StartGame()
    {
        _spawner.ResetPool();
        _bird.ResetPlayer();
        _spawner.StartSpawning();
        Time.timeScale = 1;
    }
}