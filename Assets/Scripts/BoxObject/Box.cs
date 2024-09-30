using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace BoxObject
{
    public class Box : MonoBehaviour, IDamageable
    {
        private const int MinHealth = 0;
        private const float Delay = 0.5f;

        [SerializeField] private float _speedRepulsion;
        [SerializeField] private int _health;

        public event Action Died;

        private WaitForSeconds _waitForSeconds;

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