using System;
using Envierment;
using Interfaces;
using PlatformLogic;
using Sound;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(Ball), typeof(BallEffect))]
    public class BallMovement : MonoBehaviour
    {
        private const int Divider = 2;
        private const int MinValue = 0;
        private const int MaxSpeed = 4000;
        private const int Damage = 1;
        private const int CountDistance = 15;
        private const float GravityValue = 0.1f;
        private const float PositionZero = 0f;
        private const float GravityPositionZ = 0.002f;

        [SerializeField] private Platform _platformTargetGravity;
        [SerializeField] private Transform _ballPoint;
        [SerializeField] private BallSound _ballSound;
        [SerializeField] private float _speed;

        public event Action BoxTriggered;

        private BallEffect _ballEffect;
        private Rigidbody _rigidbody;
        private Vector3 _currentDirection = Vector3.forward;
        private Vector3 _lastPlatformPosition;
        private Vector3 _lastVelosity;
        private Ball _ball;
        private bool _isGravityPlatform = false;
        private float _startSpeed;

        public Transform Transform { get; private set; }

        private void Awake()
        {
            _ballEffect = GetComponent<BallEffect>();
            _rigidbody = GetComponent<Rigidbody>();
            _ball = GetComponent<Ball>();
            Transform = transform;
            _startSpeed = _speed;
            _rigidbody.isKinematic = true;
            _ballEffect.SetStateEffect(false);
        }

        private void OnEnable() => _ball.Actived += OnSetActive;

        private void OnDisable() => _ball.Actived -= OnSetActive;

        private void FixedUpdate()
        {
            if (_ball.IsActive == false)
            {
                FollowToPointPosition();
                return;
            }

            _ballEffect.RotateTarget(_rigidbody.velocity);
            _lastVelosity = _rigidbody.velocity;
            _lastPlatformPosition = _platformTargetGravity.transform.position;

            _currentDirection += new Vector3(PositionZero, PositionZero, -GravityPositionZ);

            if (_isGravityPlatform == true)
            {
                if (Vector3.Distance(_platformTargetGravity.transform.position, Transform.position) > CountDistance) return;
                Vector3 direction = (_platformTargetGravity.transform.position - Transform.position).normalized;
                _currentDirection += new Vector3(direction.x * GravityValue, PositionZero, PositionZero);
            }

            Move(_currentDirection, _speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_ball.IsActive == false) return;

            SetSpeed();
            Collision currentCollision = collision;
            Vector3 currentPoint = currentCollision.contacts[MinValue].point;

            if (currentCollision.gameObject.TryGetComponent(out ITrigger trigger))
            {
                trigger.Play(currentPoint);

                if (currentCollision.gameObject.TryGetComponent(out Fence fence) && fence.IsOpenPortal == true)
                {
                    fence.Relocate(this, currentPoint, _currentDirection);
                    _ballSound.Play(fence.GetClip());
                    return;
                }

                _currentDirection = Vector3.Reflect(_lastVelosity, collision.contacts[MinValue].normal).normalized;
            }

            if (currentCollision.gameObject.TryGetComponent(out ISound sound))
                _ballSound.Play(sound.GetClip());

            if (currentCollision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Damage);
                BoxTriggered?.Invoke();
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            float degreeSpeed = 20;

            if (collision.gameObject.TryGetComponent(out Platform platform))
            {
                _speed += degreeSpeed *= degreeSpeed;
                Vector3 newDirection = _lastPlatformPosition - _platformTargetGravity.transform.position;
                _currentDirection = (_currentDirection - newDirection).normalized;
            }
        }

        public void SetGravity() => _isGravityPlatform = !_isGravityPlatform;

        public void SetMaxSpeed() => _speed = MaxSpeed;

        public void SetStandartSpeed() => _speed = _startSpeed;

        public void Move(Vector3 direction) => Move(direction, _speed);

        private void FollowToPointPosition() => Transform.position = _ballPoint.position;

        private void Move(Vector3 direction, float speed) => _rigidbody.velocity = speed * Time.fixedDeltaTime * direction;

        private void SetSpeed()
        {
            if (_speed < MinValue) _speed = _startSpeed;

            if (_speed > _startSpeed) _speed -= (_speed - _startSpeed) / Divider;
        }

        private void OnSetActive()
        {
            _rigidbody.isKinematic = false;
            _ballEffect.SetStateEffect(true);
        }
    }
}