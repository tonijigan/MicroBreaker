using Interfaces;
using UnityEngine;

namespace Platform
{
    [RequireComponent(typeof(Rigidbody))]
    public class Platform : MonoBehaviour, ITrigger
    {
        public Rigidbody Rigidbody { get; private set; }

        public float GetSpeed()
        {
            float speed = 10;
            float addSpeed = 30;

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