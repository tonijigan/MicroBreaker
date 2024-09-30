using Interfaces;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(Ball))]
    public class BallMovement : MonoBehaviour
    {
        private const float RandomValue = 0.1f;
        private const int Damage = 1;

        [SerializeField] private float _speed;
        [SerializeField] private Transform _ballPoint;

        private Rigidbody _rigidbody;
        private Transform _transform;
        private Vector3 _lastVelosity;
        private Ball _ball;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _ball = GetComponent<Ball>();
            _transform = transform;
        }

        private void Update()
        {
            if (_ball.IsActive == false)
            {
                _transform.position = _ballPoint.position;
            }

            _lastVelosity = _rigidbody.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITrigger trigger))
            {
                Vector3 direction = Vector3.Reflect(_lastVelosity.normalized, collision.contacts[0].normal);
                Move(GetRandomDirection(direction), GetCurrentSpeed(trigger.GetSpeed()));

                if (collision.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(Damage);
                }
            }
        }
        public void StartMove(Vector3 direction)
        {
            Move(GetRandomDirection(direction), _speed);
        }

        private float GetCurrentSpeed(float value)
        {
            if (_lastVelosity.magnitude > value)
                return _lastVelosity.magnitude;
            else return value;
        }

        private void Move(Vector3 direction, float speed)
        {
            _rigidbody.velocity = speed * direction;
        }

        private Vector3 GetRandomDirection(Vector3 direction)
        {
            return new(Random.Range(direction.x - RandomValue, direction.x + RandomValue), direction.y, direction.z);
        }
    }
}