using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _delay;

    private Coroutine _spawnPipesJob;

    private void Start(){
        Initialize(_prefab);
        _spawnPipesJob = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies(){
        
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while(true){

            if(TryGetObject(out GameObject enemy)){
                float spawnPointY = Random.Range(_minPositionY,_maxPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x,spawnPointY,transform.position.z);
                enemy.SetActive(true);
                enemy.transform.position = spawnPoint;
                EnemyShooter shooter = enemy.GetComponent<EnemyShooter>();
            }

            yield return delay;
        }
    }
}
