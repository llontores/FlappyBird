using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _delay;

    private Coroutine _spawnPipesJob;

    private void Start(){
        Initialize(_prefab);
        _spawnPipesJob = StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes(){
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while(true){
            if(TryGetObject(out GameObject pipe)){
                float spawnPointY = Random.Range(_minPositionY,_maxPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x,spawnPointY,transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                
                DisableObjectsAbroadScreen();
            }

            yield return delay;
        }
    }
}
