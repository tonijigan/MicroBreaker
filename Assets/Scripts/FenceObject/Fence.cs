using Interfaces;
using UnityEngine;

namespace FenceObject
{
    public class Fence : MonoBehaviour, IEffect, ITrigger
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public float GetSpeed()
        {
            float speed = 20;
            return speed;
        }

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }
    }
}