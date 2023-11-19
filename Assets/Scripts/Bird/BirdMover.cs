using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BirdInput))]
public class BirdMover : MonoBehaviour
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
    private BirdInput _input;
    private Animator _animator;
    public event UnityAction Died;

    private void OnEnable()
    {
        _input.JumpKeyPressed += Jump;
    }

    private void OnDisable()
    {
        _input.JumpKeyPressed -= Jump;
    }

    private void Awake()
    {
        _input = GetComponent<BirdInput>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        Reset();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }

    private void Jump()
    {
        _animator.SetTrigger("FlowUp");
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }
}
