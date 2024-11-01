using PlayerObject;
using System;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _ballPoint;

        public event Action Actived;

        private Transform _transform;

        public Rigidbody Rigidbody { get; private set; }

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
            Rigidbody = GetComponent<Rigidbody>();
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