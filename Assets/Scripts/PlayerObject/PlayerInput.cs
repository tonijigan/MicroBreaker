using Scripts;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PlayerObject
{
    public class PlayerInput : MonoBehaviour
    {
        private const string AxsisX = "Mouse X";
        private const string AxsisY = "Mouse Y";

        public event Action<Vector3, Vector3> MousePressed;
        public event Action<bool> MouseUped;
        public event Action MousePressedUp;

        private bool _isInputPlatform;

        public bool IsControl { get; private set; } = false;

        private void Update()
        {
            if (IsControl == false)
                return;

            if (IsMouseOverUI() == true) return;

            if (Input.GetMouseButton(0))
            {
                MouseUped?.Invoke(Input.GetMouseButton(0));
                MousePressed?.Invoke(GetPosition(), GetRaycastPoint());
            }
            else
            {
                MouseUped?.Invoke(Input.GetMouseButtonUp(0));
            }


            if (Input.GetMouseButtonUp(0) && _isInputPlatform == true)
            {
                MousePressedUp?.Invoke();
            }
        }

        public void SetControl()
        {
            IsControl = !IsControl;
        }

        private Vector3 GetRaycastPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _isInputPlatform = hit.collider.gameObject.TryGetComponent(out Ground ground);
                return hit.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

        private bool IsMouseOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private Vector3 GetPosition()
        {
            float positionX = Input.GetAxis(AxsisX);
            float positionY = Input.GetAxis(AxsisY);
            return new Vector3(positionX, 0, positionY);
        }
    }
}