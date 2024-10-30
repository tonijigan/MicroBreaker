using Interfaces;
using UnityEngine;

namespace PlatformObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Platform : MonoBehaviour, IEffect, ITrigger
    {
        private const float PlatformSpeed = 1500;
        private const float PositionZ = 2.5f;

        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private InputPointMovement _inputPointMovement;
        [SerializeField] private float _speed;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Transform _transformTemplateContainer;
        [SerializeField] private ParticleSystem _particleExplosion;
        [SerializeField] private AudioSource _audioSourceEffect;
        [SerializeField] private AudioClip _audioClipExplosion;

        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            FollowToPointMovement();
        }

        public float GetSpeed()
        {
            float addSpeed = 100;

            if (_rigidbody.velocity.magnitude > _speed)
                _speed = _rigidbody.velocity.magnitude + addSpeed;
            return _speed;
        }

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }

        public AudioClip GetClip()
        {
            return _audioClip;
        }

        public void Die()
        {
            _audioSourceEffect.clip = _audioClipExplosion;
            _audioSourceEffect.Play();
            _particleExplosion.Play();
            _inputPointMovement.gameObject.SetActive(false);
            _transformTemplateContainer.gameObject.SetActive(false);
        }

        private void FollowToPointMovement()
        {
            Vector3 direction = _inputPointMovement.transform.position - _transform.position;
            Vector3 newDirection = new(direction.x, direction.y, direction.z + PositionZ);
            _rigidbody.velocity = PlatformSpeed * Time.deltaTime * newDirection;
        }
    }
}