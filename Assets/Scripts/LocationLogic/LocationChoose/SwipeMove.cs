using PlatformLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LocationLogic.LocationChoose
{
    [RequireComponent(typeof(Rigidbody))]
    public class SwipeMove : MonoBehaviour
    {
        private const float ClampX = 60f;
        private const float ClampYMin = -1500;
        private const float ClampYMax = 10;
        private const float SwipeTime = 0.2f;

        [SerializeField] private LocationChooseInput _inputLocation;
        [SerializeField] private float _speedSwipe;

        private readonly Restrictor _restrict = new();
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Vector3 _offSet;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private float _swipeTime = 0;
        private bool _isDragging = false;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnMouseDown()
        {
            if (IsInputUI()) return;

            _offSet = _transform.position - GetHit().point;
            _inputLocation.SetFirstLocationObject(Input.mousePosition);
        }

        private void OnMouseDrag()
        {
            if (IsInputUI()) return;

            _swipeTime += Time.deltaTime;

            if (_swipeTime > SwipeTime) _isDragging = true;

            Vector3 direction = GetHit().point + _offSet;
            _transform.position = new(direction.x, _transform.position.y, direction.z);
        }

        private void OnMouseUp()
        {
            _swipeTime = 0;

            if (_isDragging == false) _inputLocation.SetLastLocationObject(Input.mousePosition);

            _isDragging = false;
            _inputLocation.LoadLocation();

            if (IsInputUI()) return;
        }

        private void Update() => _restrict.RestrictMove(_transform, ClampX, ClampYMin, ClampYMax);

        private RaycastHit GetHit()
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit);
            return raycastHit;
        }

        private bool IsInputUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}