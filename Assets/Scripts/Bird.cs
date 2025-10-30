using UnityEngine;
using Zenject;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private SignalBus _signalBus;
    private BirdMover _mover;
    private int _score;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _mover.Reset();
        _score = 0;
        _signalBus.Fire(new ScoreChangedSignal(){Score = _score});
    }

    public void Die()
    {
        _signalBus.Fire(new GameOverSignal());
    }

    public void IncreaseScore(){
        _score++;
        _signalBus.Fire(new ScoreChangedSignal(){Score = _score});
    }
}
