using PlayerObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody), typeof(BallEffect))]
    public class Ball : MonoBehaviour
    {
        private const int MinExtraLive = 0;
        private const int MaxExtraLive = 9;

        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _ballPoint;

        public event Action Actived;
        public event Action<int> ExtraLiveChanged;

        private Transform _transform;

        public Rigidbody Rigidbody { get; private set; }

        public BallEffect BallEffect { get; private set; }

        public int ExtraLive { get; private set; } = MinExtraLive;

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
            Rigidbody = GetComponent<Rigidbody>();
            BallEffect = GetComponent<BallEffect>();
            BallEffect.SetStateEffect(false);
        }

        private void OnEnable() => _playerInput.MousePressedUp += DisconnectParentObject;

        private void OnDisable() => _playerInput.MousePressedUp -= DisconnectParentObject;

        public void AddExtraLive(int extraLive)
        {
            if (extraLive < MinExtraLive && extraLive > MaxExtraLive) return;

            ExtraLive = extraLive;
            ExtraLiveChanged?.Invoke(ExtraLive);
        }

        public void GiveLive()
        {
            ExtraLive--;
            ExtraLiveChanged?.Invoke(ExtraLive);
            gameObject.SetActive(true);
            BallEffect.SetStateEffect(false);
        }

        public void Die()
        {
            IsActive = false;
            BallEffect.SetStateEffect(false);
            _transform.position = _ballPoint.position;
        }

        public void DisconnectParentObject()
        {
            if (IsActive)
                return;

            IsActive = true;
            BallEffect.SetStateEffect(true);
            _transform.parent = default;
            Actived?.Invoke();
        }
    }
}