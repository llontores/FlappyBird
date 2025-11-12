using UnityEngine;

[CreateAssetMenu(fileName = "BirdConfig", menuName = "Configs/BirdConfig", order = 51)]
public class BirdConfig : ScriptableObject
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    public float TapForce => _tapForce;
    public float Speed => _speed;
    public float MaxRotationZ => _maxRotationZ;
    public float MinRotationZ => _minRotationZ;
    public Vector3 StartPosition => _startPosition;
    public float RotationSpeed => _rotationSpeed;
    public float MaxPositionY => _maxPositionY;
    public float MinPositionY => _minPositionY;
}