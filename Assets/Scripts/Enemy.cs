using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AliveObject
{
    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public override void IncreaseHealth(float damage)
    {
        base.IncreaseHealth(damage);

        if (_health <= 0)
            gameObject.SetActive(false);
    }
}
