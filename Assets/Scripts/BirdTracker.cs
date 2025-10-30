using UnityEngine;
using Zenject;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    private Transform _player;

    [Inject]
    public void Construct(Bird bird)
    {
        _player = bird.transform;
    }
    
    private void Update(){
        transform.position = new Vector3(_player.position.x - _xOffset,transform.position.y,transform.position.z);
    }
}
