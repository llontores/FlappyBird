using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveObject : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;

    protected float _health;

    public virtual void IncreaseHealth(float damage)
    {
        _health -= damage;
    }
}
