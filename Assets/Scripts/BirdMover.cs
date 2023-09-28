using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    public event UnityAction Died;

    private void Start(){
        _animator = GetComponent<Animator>();
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector2.zero;
        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
        _minRotation = Quaternion.Euler(0,0,_minRotationZ);
    }

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Space)){

            if(transform.position.y > _minPositionY & transform.position.y < _maxPositionY){
                _animator.SetTrigger("FlowUp");
                _rigidbody.velocity = new Vector2(_speed,0);
                transform.rotation = _maxRotation;
                _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        
        if(collider.TryGetComponent(out Wall wall)){
            Died?.Invoke();
        }
    }
}
