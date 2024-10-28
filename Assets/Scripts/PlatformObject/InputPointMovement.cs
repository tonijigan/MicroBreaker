using PlayerObject;
using UnityEngine;

namespace PlatformObject
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

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

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

        private void HaveInputPressed(bool isActive)
        {
            _inputObject.SetActive(isActive);
        }

        private void OnMove(Vector3 position, Vector3 raycastPoint)
        {
            FollowToPointOfPressing(raycastPoint);
            Move(position);
            RestrictMove();
        }

        private void FollowToPointOfPressing(Vector3 hitPoint)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, hitPoint, MaxDistanceDelta * Time.deltaTime);
            Vector3 currentPosition = _transform.position;
            currentPosition.y = CurrentPositionY;
            _transform.position = currentPosition;
        }

        private void Move(Vector3 position)
        {
            _transform.Translate(Speed * Time.deltaTime * position);
        }

        private void RestrictMove()
        {
            float positionX = Mathf.Clamp(_transform.position.x, -ClampX, ClampX);
            float positionY = Mathf.Clamp(_transform.position.z, ClampYMin, ClampYMax);
            Vector3 clampPosition = new(positionX, _transform.position.y, positionY);
            _transform.position = clampPosition;
        }
    }
}