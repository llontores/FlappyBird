using TMPro;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private SignalBus _signalBus;
    private Bird _bird;

    [Inject]
    public void Construct(SignalBus signalBus, Bird bird)
    {
        _signalBus = signalBus;
        _bird = bird;
    }
    
    private void OnEnable()
    {
        _signalBus.Subscribe<ScoreChangedSignal>(Display);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<ScoreChangedSignal>(Display);
    }

    private void Display(ScoreChangedSignal args)
    {
        _text.text = args.Score.ToString();
    }
}