using Interfaces;
using PlayerObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(Ball), typeof(BallEffect))]
    public class BallMovement : MonoBehaviour
    {
        private const float RandomValue = 0.1f;
        private const float PositionZero = 0f;
        private const float GravityPositionZ = 0.02f;
        private const int Damage = 1;

        [SerializeField] private Transform _ballPoint;
        [SerializeField] private float _speed;

        public event Action BoxTriggered;
        public event Action<AudioClip> BallTriggered;

        private BallEffect _ballEffect;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Vector3 _lastVelosity;
        private Ball _ball;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ball = GetComponent<Ball>();
            _ballEffect = GetComponent<BallEffect>();
            _transform = transform;
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
            _ballEffect.RotateTarget(_rigidbody.velocity);
            _lastVelosity = _rigidbody.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_ball.IsActive == false)
                return;

            if (collision.gameObject.TryGetComponent(out ITrigger trigger))
            {
                Vector3 direction = Vector3.Reflect(_lastVelosity.normalized, collision.contacts[0].normal);
                Move(direction, GetCurrentSpeed(trigger.GetSpeed()));
                BallTriggered?.Invoke(trigger.GetClip());
            }

            if (collision.gameObject.TryGetComponent(out IEffect effect))
            {
                effect.Play(collision.contacts[0].point);
            }

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Damage);
                BoxTriggered?.Invoke();
            }
        }

        public void FollowToPointPosition()
        {
            _transform.position = _ballPoint.position;
        }

        public float GetCurrentSpeed(float value)
        {
            if (_lastVelosity.magnitude > value)
                return _lastVelosity.magnitude;
            else return value;
        }

        private void OnMove()
        {
            _rigidbody.AddForce(_speed * Vector3.forward, ForceMode.Impulse);
        }

        private void Move(Vector3 direction, float speed)
        {
            _rigidbody.velocity = speed * Time.deltaTime * direction;
        }

        public Vector3 GetRandomDirection(Vector3 direction)
        {
            return new(UnityEngine.Random.Range(direction.x - RandomValue, direction.x + RandomValue), direction.y, direction.z);
        }
    }
}