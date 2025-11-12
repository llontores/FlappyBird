using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity; 
    public GameObject Container => _container;
    
    private Queue<GameObject> _pool = new Queue<GameObject>();

    protected void Initialize(GameObject prefab){
        
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab,_container.transform);
            spawned.SetActive(false);

            _pool.Enqueue(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result){
        result = _pool.Count > 0 ? _pool.Dequeue() : null;
        return result != null;
    }

    public void ResetPool()
    {
        _pool.Clear();
        
        foreach (Transform child in _container.transform)
        {
            child.gameObject.SetActive(false);
            _pool.Enqueue(child.gameObject);
        }
    }

    public void ReturnObject(GameObject pipe)
    {
        pipe.SetActive(false);
        _pool.Enqueue(pipe);
    }
}
