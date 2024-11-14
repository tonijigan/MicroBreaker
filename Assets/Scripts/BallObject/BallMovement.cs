using FenceObject;
using Interfaces;
using PlatformObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(Ball), typeof(BallEffect))]
    public class BallMovement : MonoBehaviour
    {
        private const int MaxSpeed = 4000;
        private const int StandartSpeed = 1000;
        private const float GravityValue = 0.05f;
        private const float PositionZero = 0f;
        private const float GravityPositionZ = 0.02f;
        private const int Damage = 1;

        [SerializeField] private Platform _platformTargetGravity;
        [SerializeField] private Transform _ballPoint;
        [SerializeField] private BallSound _ballSound;
        [SerializeField] private float _speedForce;

        public event Action BoxTriggered;

        private BallEffect _ballEffect;
        private Rigidbody _rigidbody;
        private Vector3 _lastVelosity;
        private Ball _ball;
        private bool _isGravityPlatform = false;
        private float _currentSpeed = StandartSpeed;

        public Transform Transform { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ball = GetComponent<Ball>();
            _ballEffect = GetComponent<BallEffect>();
            Transform = transform;
        }

        private void OnEnable()
        {
            _ball.Actived += OnMove;
        }

        private void OnDisable()
        {
            _ball.Actived -= OnMove;
        }
        private void Update()
        {
            if (_ball.IsActive == false)
            {
                FollowToPointPosition();
                return;
            }

            _rigidbody.velocity += new Vector3(PositionZero, PositionZero, -GravityPositionZ);

            if (_isGravityPlatform == true)
            {
                Vector3 direction = (_platformTargetGravity.transform.position - Transform.position).normalized;
                _rigidbody.velocity += new Vector3(direction.x * GravityValue, PositionZero, -GravityPositionZ);
            }

            _ballEffect.RotateTarget(_rigidbody.velocity);
            _lastVelosity = _rigidbody.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_ball.IsActive == false)
                return;

            Collision currentCollision = collision;
            Vector3 currentPoint = currentCollision.contacts[0].point;

            if (currentCollision.gameObject.TryGetComponent(out ITrigger trigger))
            {
                trigger.Play(currentPoint);

                if (currentCollision.gameObject.TryGetComponent(out Fence fence) && fence.IsOpenPortal == true)
                {
                    fence.Relocate(this, currentPoint, GetCurrentDirection(collision));
                    _ballSound.Play(fence.GetClip());
                    return;
                }

                Move(GetCurrentDirection(currentCollision), GetCurrentSpeed(trigger.GetSpeed()));
            }

            if (currentCollision.gameObject.TryGetComponent(out ISound sound))
                _ballSound.Play(sound.GetClip());

            if (currentCollision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Damage);
                BoxTriggered?.Invoke();
            }
        }

        public void SetGravity() => _isGravityPlatform = !_isGravityPlatform;

        public void FollowToPointPosition() => Transform.position = _ballPoint.position;

        public void SetMaxSpeed() => _currentSpeed = MaxSpeed;

        public void SetStandartSpeed() => _currentSpeed = StandartSpeed;

        public float GetCurrentSpeed(float value)
        {
            if (value < _currentSpeed) return _currentSpeed;
            else return value;
        }

        public void Move(Vector3 direction) => Move(direction, _currentSpeed);

        private void Move(Vector3 direction, float speed) => _rigidbody.velocity = speed * Time.deltaTime * direction;

        private void OnMove() => _rigidbody.AddForce(_speedForce * Vector3.forward, ForceMode.Impulse);

        public Vector3 GetCurrentDirection(Collision collision)
        {
            return Vector3.Reflect(_lastVelosity.normalized, collision.contacts[0].normal);
        }
    }
}