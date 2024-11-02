using System;
using System.Collections;
using Boosters;
using Enums;
using Interfaces;
using UnityEngine;

namespace BoxObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Box : MonoBehaviour, IDamageable, ITrigger
    {
        private const int MinHealth = 0;
        private const float Delay = 0.5f;

        [SerializeField] private float _speedRepulsion;
        [SerializeField] private int _health;
        [SerializeField] private BoosterNames _boosterName;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioClip _audioClipDie;

        public event Action Died;
        public event Action<AudioClip> Damaged;

        private Rigidbody _rigidbody;
        private BoosterEffect _booster;
        private WaitForSeconds _waitForSeconds;
        private ParticleSystem _particleSystem;

        public BoosterNames BoosterName => _boosterName;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void SetKinematic(bool isKinematic) => _rigidbody.isKinematic = isKinematic;

        public void Init(BoosterEffect booster, ParticleSystem particleSystem)
        {
            if (booster != null)
                _booster = booster;

            _particleSystem = particleSystem;
        }

        public void Init(ParticleSystem particleSystem) => _particleSystem = particleSystem;

        public float GetSpeed()
        {
            return _speedRepulsion;
        }

        public void TakeDamage(int damage)
        {
            if (_health <= MinHealth)
            {
                StartCoroutine(Die());
                Died?.Invoke();

                if (_booster != null)
                {
                    _booster.transform.position = transform.position;
                    _booster.gameObject.SetActive(true);
                }
            }

            _health -= damage;
            Damaged?.Invoke(GetClip());
        }

        public void Play(Vector3 point)
        {
            _particleSystem.transform.position = point;
            _particleSystem.Play();
        }

        private IEnumerator Die()
        {
            _waitForSeconds = new(Delay);
            yield return _waitForSeconds;
            gameObject.SetActive(false);
            StopCoroutine(Die());
        }

        private AudioClip GetClip()
        {
            if (_health <= MinHealth)
                return _audioClipDie;

            return _audioClip;
        }
    }
}