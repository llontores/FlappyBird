using UnityEngine;
using Zenject;

public class PipesDisabler : MonoBehaviour
{
    private ObjectPool _pool;
    private Camera _camera;

    [Inject]
    public void Construct(ObjectPool pool)
    {
        _pool = pool;
    }
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (Transform child in _pool.Container.transform)
        {
            if (child.gameObject.activeSelf == true && child.position.x < disablePoint.x)
            {
                _pool.ReturnObject(child.gameObject);
            }
        }
    }
}