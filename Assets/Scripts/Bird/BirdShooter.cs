using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdInput))]
public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    private BirdInput _input;

    private void Awake()
    {
        _input = GetComponent<BirdInput>();
    }

    private void OnEnable()
    {
        _input.ShootKeyPressed += Shoot;
    }

    private void OnDisable()
    {
        _input.ShootKeyPressed -= Shoot;
    }

    private void Shoot() 
    {
        Bullet fireball = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        fireball.SetDirection(Vector2.right);
    }

}
