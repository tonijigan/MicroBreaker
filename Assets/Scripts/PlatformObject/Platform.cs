using Interfaces;
using UnityEngine;

namespace PlatformObject
{
    public class Platform : MonoBehaviour, ITrigger, ISound
    {
        [SerializeField] private InputPointMovement _inputPointMovement;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ParticleSystem _particleExplosion;
        [SerializeField] private Transform _transformTemplateContainer;
        [SerializeField] private AudioSource _audioSourceEffect;
        [SerializeField] private AudioClip _audioClipExplosion;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private float _speedForceBall;

        private void Start() => SetStartState();

        private void SetStartState() => _inputPointMovement.transform.position = _startPoint.position;

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }

        public void GiveLive()
        {
            _transformTemplateContainer.gameObject.SetActive(true);
            _inputPointMovement.gameObject.SetActive(true);
            SetStartState();
        }

        public void Die()
        {
            _audioSourceEffect.clip = _audioClipExplosion;
            _audioSourceEffect.Play();
            _particleExplosion.Play();
            _transformTemplateContainer.gameObject.SetActive(false);
            _inputPointMovement.gameObject.SetActive(false);
        }

        public float GetSpeed()
        {
            return _speedForceBall;
        }
        public AudioClip GetClip()
        {
            return _audioClip;
        }
    }
}