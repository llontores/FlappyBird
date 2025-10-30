using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Game>().AsSingle();
        Container.Bind<Bird>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PipeSpawner>().FromComponentInHierarchy().AsSingle();
        Container.Bind<StartScreen>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameOverScreen>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Score>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BirdTracker>().FromComponentInHierarchy().AsSingle();
        
        SignalBusInstaller.Install(Container);
        
        Container.DeclareSignal<PlayButtonClickedSignal>();
        Container.DeclareSignal<ScoreChangedSignal>();
        Container.DeclareSignal<RestartButtonClickedSignal>();
        Container.DeclareSignal<GameOverSignal>();
    }
}
