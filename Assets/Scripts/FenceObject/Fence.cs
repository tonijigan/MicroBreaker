using Interfaces;
using UnityEngine;

namespace FenceObject
{
    public class Fence : MonoBehaviour, ITrigger, ISound
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private float _speed;
        [SerializeField] private AudioClip _audioClip;

        public AudioClip GetClip()
        {
            return _audioClip;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }
    }
}