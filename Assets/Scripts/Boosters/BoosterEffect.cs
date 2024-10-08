using Enums;
using System;
using UnityEngine;

namespace Boosters
{
    public class BoosterEffect : MonoBehaviour
    {
        private const float PositionZero = 0;
        private const float PositionZ = 1;

        [SerializeField] private float _speed;
        [SerializeField] private BoosterNames _boosterName;

        public event Action Collided;

        public BoosterNames BoosterName => _boosterName;

        private void Update()
        {
            transform.Translate(new(PositionZero, PositionZero, -PositionZ * _speed * Time.deltaTime));
        }

        public void PlayAction()
        {
            Collided?.Invoke();
        }
    }
}