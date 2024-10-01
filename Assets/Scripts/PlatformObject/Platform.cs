using Interfaces;
using UnityEngine;

namespace PlatformObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Platform : AbstractEffect
    {
        public Rigidbody Rigidbody { get; private set; }

        public float GetSpeed()
        {
            float speed = 50;
            float addSpeed = 10;

            if (Rigidbody.velocity.magnitude > speed)
                speed = Rigidbody.velocity.magnitude + addSpeed;
            return speed;
        }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}