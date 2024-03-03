using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : AliveObject
{
    public event UnityAction GameOver;
    public event UnityAction<float> HealthChanged;

    private BirdMover _mover;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _health = _maxHealth;
        _mover.Reset();
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public override void IncreaseHealth(float damage){
        base.IncreaseHealth(damage);

        HealthChanged?.Invoke(_health);
        if (_health <= 0)
            Die();
    }
}
