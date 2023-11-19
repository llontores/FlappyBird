using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public float Damage => _damage;
    private Vector2 _direction;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
            bird.IncreaseHealth(_damage);
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.IncreaseHealth(_damage);
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        if (direction == Vector2.left)
            _renderer.flipX = true;
    }
}
