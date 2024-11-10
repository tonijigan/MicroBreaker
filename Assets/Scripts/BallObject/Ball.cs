using PlayerObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(BallEffect))]
    public class Ball : MonoBehaviour
    {
        private const int MaxExtraLive = 9;

        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _ballPoint;

        public event Action Actived;

        private Transform _transform;

        public Rigidbody Rigidbody { get; private set; }

        public BallEffect BallEffect { get; private set; }

        public int ExtraLive { get; private set; } = 0;

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
            Rigidbody = GetComponent<Rigidbody>();
            BallEffect = GetComponent<BallEffect>();
        }

        private void OnEnable() => _playerInput.MousePressedUp += DisconnectParentObject;

        private void OnDisable() => _playerInput.MousePressedUp -= DisconnectParentObject;

        public void AddExtraLive(int extraLive)
        {
            if (extraLive < 0 && extraLive > MaxExtraLive) return;

            ExtraLive = extraLive;
            Debug.Log(ExtraLive);
        }

        public void DisconnectParentObject()
        {
            if (IsActive)
                return;

            IsActive = true;
            _transform.parent = default;
            Actived?.Invoke();
        }
    }
}