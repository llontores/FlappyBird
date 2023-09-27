using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start(){
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
        _minRotation = Quaternion.Euler(0,0,_minRotationZ);
    }

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Space)){
            _rigidbody.velocity = new Vector2(_speed,0);
            transform.rotation = _maxRotation;
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
