using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _shootPoint;

    private Coroutine _shootJob;

    private void OnDisable()
    {
        StopCoroutine(_shootJob);
    }

    private void OnEnable()
    {
        _shootJob = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        while (_delay >= Time.deltaTime)
        {
            Bullet fireball = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            fireball.SetDirection(Vector2.left);

            yield return delay;
        }
    }

}
