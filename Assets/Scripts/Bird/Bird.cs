using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdConfig _config;
    
    private SignalBus _signalBus;
    private BirdMover _mover;
    private int _score;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mover = new  BirdMover(_rigidbody2D, transform, _animator, _config);
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

    private void Update()
    {
        _mover.ProcessMovement();
    }
}
