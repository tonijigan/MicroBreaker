using System;
using System.Collections;
using Boosters;
using EffectObjects;
using Enums;
using Interfaces;
using UnityEngine;

namespace BoxObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Box : AbstractEffect, IDamageable
    {
        private const int MinHealth = 0;
        private const float Delay = 0.5f;

        [SerializeField] private float _speedRepulsion;
        [SerializeField] private int _health;
        [SerializeField] private BoosterNames _boosterName;

        public event Action Died;

        private Rigidbody _rigidbody;
        private BoosterEffect _booster;
        private WaitForSeconds _waitForSeconds;

        public BoosterNames BoosterName => _boosterName;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetKinematic(bool isKinematic)
        {
            _rigidbody.isKinematic = isKinematic;
        }

        public void Init(BoosterEffect booster, ParticleSystem particleSystem)
        {
            if (booster != null)
                _booster = booster;

            ParticleSystem = particleSystem;
        }

        public void Init(ParticleSystem particleSystem)
        {
            ParticleSystem = particleSystem;
        }

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
        }

        private IEnumerator Die()
        {
            _waitForSeconds = new(Delay);
            yield return _waitForSeconds;
            gameObject.SetActive(false);
            StopCoroutine(Die());
        }
    }
}