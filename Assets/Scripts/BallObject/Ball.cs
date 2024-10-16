using PlayerObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(BallMovement))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _ballPoint;

        public event Action Actived;

        private Transform _transform;

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            _playerInput.MousePressedUp += DisconnectParentObject;
        }

        private void OnDisable()
        {
            _playerInput.MousePressedUp -= DisconnectParentObject;
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