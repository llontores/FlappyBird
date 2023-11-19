using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction GameOver;
    public event UnityAction<float> HealthChanged;
    private BirdMover _mover;
    private int _score;
    private float _health;

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

    public void IncreaseHealth(float damage){
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
            Die();
    }
}
