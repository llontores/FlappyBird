using UnityEngine;

public class BirdMover
{
    private static readonly int FlowUpTrigger = Animator.StringToHash("FlowUp");
    
    private float _tapForce;
    private float _speed;
    private float _maxRotationZ;
    private float _minRotationZ;
    private Vector3 _startPosition;
    private float _rotationSpeed;
    private float _maxPositionY;
    private float _minPositionY;
    private BirdConfig _config;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Transform _transform;

    public BirdMover(Rigidbody2D rigidbody, Transform transform, Animator animator, BirdConfig config)
    {
        _animator = animator;
        _rigidbody = rigidbody;
        _transform = transform;
        _tapForce = config.TapForce;
        _speed = config.Speed;
        _maxRotationZ = config.MaxRotationZ;
        _minRotationZ = config.MinRotationZ;
        _startPosition = config.StartPosition;
        _rotationSpeed = config.RotationSpeed;
        _maxPositionY = config.MaxPositionY;
        _minPositionY = config.MinPositionY;

        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
        _minRotation = Quaternion.Euler(0,0,_minRotationZ);

        Reset();
    }

    public void ProcessMovement(){

        if(Input.GetMouseButtonDown(0)){

            if(_transform.position.y > _minPositionY & _transform.position.y < _maxPositionY){
                _animator.SetTrigger(FlowUpTrigger);
                _rigidbody.velocity = new Vector2(_speed,0);
                _transform.rotation = _maxRotation;
                _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            }
        }

        _transform.rotation = Quaternion.Lerp(_transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _transform.position = _startPosition;
        _transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}
