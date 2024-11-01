using Interfaces;
using UnityEngine;

namespace PlatformObject
{
    public class Platform : MonoBehaviour, IEffect
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Transform _transformTemplateContainer;
        [SerializeField] private ParticleSystem _particleExplosion;
        [SerializeField] private AudioSource _audioSourceEffect;
        [SerializeField] private AudioClip _audioClipExplosion;

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }

        public void Die()
        {
            _audioSourceEffect.clip = _audioClipExplosion;
            _audioSourceEffect.Play();
            _particleExplosion.Play();
            _transformTemplateContainer.gameObject.SetActive(false);
        }
    }
}