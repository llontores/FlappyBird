using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity; 

    private List<GameObject> _pool = new List<GameObject>();
    private Camera _camera;

    protected void Initialize(GameObject prefab){

        _camera = Camera.main;
        
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab,_container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result){
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    private void ResetPool(){
        foreach (GameObject pipe in _pool)
        {
            pipe.SetActive(false);   
        }
    }

    protected void DisableObjectsAbroadScreen(){
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (GameObject pipe in _pool)
        {
            if(pipe.activeSelf == true){
                if(pipe.transform.position.x < disablePoint.x)
                    pipe.SetActive(false);
            }
        }
    }
}