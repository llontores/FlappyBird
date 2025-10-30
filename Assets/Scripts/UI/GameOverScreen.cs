using UnityEngine.Events;
using Zenject;

public class GameOverScreen : Screen
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.gameObject.SetActive(true);
    }

    protected override void OnButtonClick()
    {
        _signalBus.Fire(new RestartButtonClickedSignal());
    }
}
