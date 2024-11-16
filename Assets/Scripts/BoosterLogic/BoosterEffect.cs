using System;
using Enums;
using UnityEngine;

namespace BoosterLogic
{
    public class BoosterEffect : MonoBehaviour
    {
        private const float PositionZero = 0;
        private const float PositionZ = 1;
        private const int MinSpeedValue = 5;
        private const int MaxSpeedValue = 15;

        [SerializeField] private BoosterNames _boosterName;
        [SerializeField] private ObjectsName _objectsName;
        [SerializeField] private bool _isCoin = false;

        private Transform _transform;
        private int _speed;

        public event Action<BoosterEffect> Collided;

        public bool IsCoin => _isCoin;

        public bool IsActive { get; private set; } = false;

        public bool IsCreated { get; private set; } = false;

        public BoosterNames BoosterName => _boosterName;

        public ObjectsName ObjectsName => _objectsName;

        private void Awake() => _transform = transform;

        private void Start() => _speed = UnityEngine.Random.Range(MinSpeedValue, MaxSpeedValue);

        private void Update() => _transform.Translate(new(PositionZero, PositionZero, -PositionZ * _speed * Time.deltaTime));

        public void HaveCreated() => IsCreated = true;

        public void SetActionActive() => IsActive = !IsActive;

        public void PlayAction() => Collided?.Invoke(this);
    }
}