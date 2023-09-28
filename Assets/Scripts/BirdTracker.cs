using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _xOffset;

    private void Update(){
        transform.position = new Vector3(_player.position.x - _xOffset,transform.position.y,transform.position.z);
    }
}
