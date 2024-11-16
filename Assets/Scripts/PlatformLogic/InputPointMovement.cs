using PlayerLogic;
using UnityEngine;

namespace PlatformLogic
{
    public class InputPointMovement : MonoBehaviour
    {
        private const float MaxDistanceDelta = 50;
        private const float Speed = 0.5f;
        private const float ClampX = 9f;
        private const float ClampYMin = -22;
        private const float ClampYMax = -6;
        private const float CurrentPositionY = 0.5f;

        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private GameObject _inputObject;

        private readonly Restrictor _restrict = new();

        public Transform Transform { get; private set; }

        private void Awake() => Transform = transform;

        private void OnEnable()
        {
            _playerInput.MousePressed += OnMove;
            _playerInput.MouseUped += HaveInputPressed;
        }

        private void OnDisable()
        {
            _playerInput.MousePressed -= OnMove;
            _playerInput.MouseUped -= HaveInputPressed;
        }

        private void HaveInputPressed(bool isActive) => _inputObject.SetActive(isActive);

        private void OnMove(Vector3 position, Vector3 raycastPoint)
        {
            FollowToPointOfPressing(raycastPoint);
            Move(position);
            _restrict.RestrictMove(Transform, ClampX, ClampYMin, ClampYMax);
        }

        private void FollowToPointOfPressing(Vector3 hitPoint)
        {
            Transform.position = Vector3.MoveTowards(Transform.position, hitPoint, MaxDistanceDelta * Time.deltaTime);
            Vector3 currentPosition = Transform.position;
            currentPosition.y = CurrentPositionY;
            Transform.position = currentPosition;
        }

        private void Move(Vector3 position) => Transform.Translate(Speed * Time.deltaTime * position);
    }
}