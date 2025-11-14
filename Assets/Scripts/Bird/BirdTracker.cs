using System;
using UnityEngine;
using Zenject;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    private Transform _player;
    private Vector3 _startPosition;
    private SignalBus _signalBus;

    [Inject]
    public void Construct(Bird bird,  SignalBus signalBus)
    {
        _player = bird.transform;
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<RestartButtonClickedSignal>(Reset);
        _startPosition = new Vector3(_player.position.x - _xOffset,transform.position.y,transform.position.z);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<RestartButtonClickedSignal>(Reset);
    }

    private void Update(){
        transform.position = new Vector3(_player.position.x - _xOffset,transform.position.y,transform.position.z);
    }

    private void Reset()
    {
        transform.position = _startPosition;
    }
}
