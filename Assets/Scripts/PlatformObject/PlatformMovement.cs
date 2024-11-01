using Interfaces;
using PlatformObject;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformMovement : MonoBehaviour, ITrigger
{
    private const float MinPlatformSpeed = 0;
    private const float PositionZ = 2.5f;

    [SerializeField] private InputPointMovement _inputPointMovement;
    [SerializeField] private float _speedForceBall;
    [SerializeField] private AudioClip _audioClip;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private float _currentPlatformSpeed;
    [SerializeField] private bool _isInverted = false;
    public float PlatformSpeed { get; private set; } = 1500;

    public Vector3 Direction { get; private set; }

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _currentPlatformSpeed = PlatformSpeed;
    }

    private void FixedUpdate() => FollowToPointMovement();

    public void ChangePlatformSpeed(float speed)
    {
        if (speed <= MinPlatformSpeed) return;
        _currentPlatformSpeed = speed;
    }

    public AudioClip GetClip()
    {
        return _audioClip;
    }

    public float GetSpeed()
    {
        float addSpeed = 100;

        if (_rigidbody.velocity.magnitude > _speedForceBall)
            _speedForceBall = _rigidbody.velocity.magnitude + addSpeed;
        return _speedForceBall;
    }

    public void EnableInverted() => _isInverted = !_isInverted;

    private void FollowToPointMovement()
    {
        Debug.Log($"Z {_inputPointMovement.Transform.position.z} / {_transform.position.z}");
        if (_isInverted == false)
            Direction = _inputPointMovement.Transform.position - _transform.position;
        else
            Direction = new(-_inputPointMovement.Transform.position.x - _transform.position.x,
                            _inputPointMovement.Transform.position.y - _transform.position.y,
                            -_inputPointMovement.Transform.position.z * 3 - _transform.position.z);

        Vector3 newDirection = new(Direction.x, Direction.y, Direction.z + PositionZ);
        _rigidbody.velocity = _currentPlatformSpeed * Time.deltaTime * newDirection;
    }
}