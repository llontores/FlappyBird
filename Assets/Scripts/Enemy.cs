using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.TryGetComponent(out Bullet bullet))
    //    {
    //        _health -= bullet.Damage;
    //        print("по мне попали");

    //        if (_health <= 0)
    //            gameObject.SetActive(false);
    //    }
    //}

    public void IncreaseHealth(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            gameObject.SetActive(false);
    }
}
