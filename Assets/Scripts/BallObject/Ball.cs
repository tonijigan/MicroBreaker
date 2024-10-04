using Player;
using UnityEngine;

namespace BallObject
{
    [RequireComponent(typeof(BallMovement))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _ballPoint;

        private Transform _transform;
        private BallMovement _ballMovement;

        public bool IsActive { get; private set; } = false;

        private void Awake()
        {
            _transform = transform;
            _ballMovement = GetComponent<BallMovement>();
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
            //_ballMovement.StartMove(Vector3.forward);
        }
    }
}