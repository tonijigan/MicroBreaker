using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace BoxObject
{
    public class Box : AbstractEffect, IDamageable
    {
        private const int MinHealth = 0;
        private const float Delay = 0.5f;

        [SerializeField] private float _speedRepulsion;
        [SerializeField] private int _health;
        [SerializeField] private BoxName _name;

        public event Action Died;

        private Booster _booster;
        private WaitForSeconds _waitForSeconds;

        public BoxName Name => _name;

        public void Init(Booster booster, ParticleSystem particleSystem)
        {
            _booster = booster;
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
                _booster.transform.position = transform.position;
                _booster.gameObject.SetActive(true);
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