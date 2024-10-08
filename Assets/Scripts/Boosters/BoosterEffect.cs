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
        [SerializeField] private ObjectsName _objectsName;

        public event Action<BoosterEffect> Collided;

        public bool IsCreated { get; private set; } = false;

        public BoosterNames BoosterName => _boosterName;

        public ObjectsName ObjectsName => _objectsName;

        private void Update()
        {
            transform.Translate(new(PositionZero, PositionZero, -PositionZ * _speed * Time.deltaTime));
        }

        public void PlayAction()
        {
            Collided?.Invoke(this);
        }

        public void HaveCreated()
        {
            IsCreated = true;
        }
    }
}