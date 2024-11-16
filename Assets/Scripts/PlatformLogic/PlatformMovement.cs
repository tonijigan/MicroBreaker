using BallObject;
using UnityEngine;

namespace PlatformLogic
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformMovement : MonoBehaviour
    {
        private const float MinPlatformSpeed = 0;
        private const float PositionZ = 2.5f;
        private const float ClampX = 9f;
        private const float ClampZMin = -22;
        private const float ClampZMax = -5;
        private const float RevercePositionZ = 30;

        [SerializeField] private InputPointMovement _inputPointMovement;
        [SerializeField] private BallMovement _ballMovement;

        private Rigidbody _rigidbody;
        private Transform _transform;
        private float _currentPlatformSpeed;
        private bool _isInverted = false;
        private readonly Restrictor _restrict = new();
        private Transform _currentTarget;
        private bool _isTargetChange = false;

        public float PlatformSpeed { get; private set; } = 1500;

        public Vector3 Direction { get; private set; }

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            _currentPlatformSpeed = PlatformSpeed;
        }

        private void FixedUpdate()
        {
            if (_isTargetChange == false) _currentTarget = _inputPointMovement.Transform;
            else _currentTarget.position = new Vector3(_ballMovement.Transform.position.x,
                                                       _ballMovement.Transform.position.y,
                                                       Mathf.Clamp(_ballMovement.Transform.position.z, ClampZMin, ClampZMax));
            FollowToPointMovement(_currentTarget);
        }
        public void ChangePlatformSpeed(float speed)
        {
            if (speed <= MinPlatformSpeed) return;
            _currentPlatformSpeed = speed;
        }

        public void ChangeTarget() => _isTargetChange = !_isTargetChange;

        public void EnableInverted() => _isInverted = !_isInverted;

        private void FollowToPointMovement(Transform transform)
        {
            if (_isInverted == false)
                Direction = transform.position - _transform.position;
            else
                Direction = new(-transform.position.x - _transform.position.x,
                                transform.position.y - _transform.position.y,
                                -transform.position.z - _transform.position.z - RevercePositionZ);

            Vector3 newDirection = new(Direction.x, Direction.y, Direction.z + PositionZ);
            _rigidbody.velocity = _currentPlatformSpeed * Time.deltaTime * newDirection;
            _restrict.RestrictMove(_transform, ClampX, ClampZMin, ClampZMax);
        }
    }
}