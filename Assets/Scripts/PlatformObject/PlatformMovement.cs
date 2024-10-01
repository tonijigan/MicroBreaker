using UnityEngine;

namespace PlatformObject
{
    public class PlatformMovement : MonoBehaviour
    {
        private const float MaxDistanceDelta = 50;
        private const float Speed = 0.5f;
        private const float ClampX = 9f;
        private const float ClampYMin = -19;
        private const float ClampYMax = -6;
        private const float CurrentPositionY = 1;
        private const float PlatformSpeed = 1500;
        private const float PositionZ = 1.5f;

        [SerializeField] private Platform _platform;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            Vector3 direction = _transform.position - _platform.transform.position;
            Vector3 newDirection = new(direction.x, direction.y, direction.z + PositionZ);
            _platform.Rigidbody.velocity = PlatformSpeed * Time.deltaTime * newDirection;
        }

        public void MoveToPointOfPressing(Vector3 hitPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, hitPoint, MaxDistanceDelta * Time.deltaTime);
            Vector3 currentPosition = transform.position;
            currentPosition.y = CurrentPositionY;
            transform.position = currentPosition;
        }

        public void Move(Vector3 position)
        {
            _transform.Translate(Speed * Time.deltaTime * position);
        }

        public void RestrictMove()
        {
            float positionX = Mathf.Clamp(_transform.position.x, -ClampX, ClampX);
            float positionY = Mathf.Clamp(_transform.position.z, ClampYMin, ClampYMax);
            Vector3 clampPosition = new(positionX, _transform.position.y, positionY);
            _transform.position = clampPosition;
        }
    }
}