using BallObject;
using PlatformObject;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlatformMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private const string AxsisX = "Mouse X";
        private const string AxsisY = "Mouse Y";

        [SerializeField] private Ball _ball;
        [SerializeField] private GameObject _inputTransform;

        private PlatformMovement _platformMovement;

        private bool _isInputPlatform;

        private void Awake()
        {
            _platformMovement = GetComponent<PlatformMovement>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _platformMovement.MoveToPointOfPressing(GetRaycastPoint());
                _platformMovement.Move(GetPosition());
                _platformMovement.RestrictMove();
                _inputTransform.SetActive(true);
            }
            else
            {
                _inputTransform.SetActive(false);
            }


            if (Input.GetMouseButtonUp(0) && _ball.IsActive == false && _isInputPlatform == true)
            {
                _ball.DisconnectParentObject();
                _inputTransform.SetActive(false);
            }
        }

        private Vector3 GetRaycastPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _isInputPlatform = !hit.collider.gameObject.TryGetComponent(out Ground ground);
                return hit.point;
            }
            else
                return Vector3.zero;
        }

        private Vector3 GetPosition()
        {
            float positionX = Input.GetAxis(AxsisX);
            float positionY = Input.GetAxis(AxsisY);
            return new Vector3(positionX, 0, positionY);
        }
    }
}