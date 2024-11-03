using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] private BoosterNames _boosterName;
        [SerializeField] private float _speedRepulsion;
        [SerializeField] private int _health;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioClip _audioClipDie;
        [SerializeField] private List<BoxTemplate> _boxTemplates;
        [SerializeField] private bool _isCanDestruction = true;

        public event Action Died;
        public event Action<AudioClip> Damaged;

        private Rigidbody _rigidbody;
        private BoosterEffect _booster;
        private WaitForSeconds _waitForSeconds;
        private ParticleSystem _particleSystem;

        public BoosterNames BoosterName => _boosterName;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            DisableBoxTemplate();
            GetTemplate(_boosterName).gameObject.SetActive(true);
        }

        public void SetChangeCanDestruction()
        {
            _isCanDestruction = !_isCanDestruction;
        }

        public void SetName(BoosterNames boosterNames)
        {
            DisableBoxTemplate();
            GetTemplate(boosterNames).gameObject.SetActive(true);
            _booster = null;
        }

        public void DisableBoxTemplate()
        {
            foreach (var box in _boxTemplates)
                box.gameObject.SetActive(false);
        }

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
            if (_isCanDestruction == false) return;

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

        private BoxTemplate GetTemplate(BoosterNames boosterNames)
        {
            return _boxTemplates.Where(box => box.BoosterNames == boosterNames).FirstOrDefault();
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