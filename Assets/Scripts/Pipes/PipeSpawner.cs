using System.Collections;
using UnityEngine;

public class PipeSpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _delay;

    private Coroutine _spawnPipesJob;
    private bool _isSpawning;

    private void Start()
    {
        Initialize(_prefab);
    }

    private IEnumerator SpawnPipes()
    {
        print(transform.position);
        _isSpawning = true;

        while (_isSpawning)
        {
            if (TryGetObject(out GameObject pipe))
            {
                float spawnPointY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPointY, transform.position.z);
                pipe.transform.position = spawnPoint;
                pipe.SetActive(true);
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    public void StopSpawning()
    {
        _isSpawning = false;

        if (_spawnPipesJob != null)
        {
            StopCoroutine(_spawnPipesJob);
            _spawnPipesJob = null;
        }
    }

    public void StartSpawning()
    {
        StopSpawning();
        _spawnPipesJob = StartCoroutine(SpawnPipes());
    }
}