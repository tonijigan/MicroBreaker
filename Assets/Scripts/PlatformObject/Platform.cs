using Interfaces;
using UnityEngine;

namespace PlatformObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Platform : MonoBehaviour, IEffect
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public Rigidbody Rigidbody { get; private set; }

        public float GetSpeed()
        {
            float speed = 20;
            float addSpeed = 10;

            if (Rigidbody.velocity.magnitude > speed)
                speed = Rigidbody.velocity.magnitude + addSpeed;
            return speed;
        }

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}