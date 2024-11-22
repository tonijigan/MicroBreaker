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

        [SerializeField] private LocationChooseInput _inputLocation;

        private readonly Restrictor _restrict = new();
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Vector3 _offSet;
        private Vector3 _startPosition;
        private Vector3 _endPosition;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnMouseDown()
        {
            if (IsInputUI())
                return;

            _startPosition = _transform.position;
            _offSet = _transform.position - GetHit().point;
            _inputLocation.SetFirstLocationObject(Input.mousePosition);
        }

        private void OnMouseDrag()
        {
            if (IsInputUI()) return;

            Vector3 direction = GetHit().point + _offSet;
            _transform.position = new(direction.x, _transform.position.y, direction.z);
        }

        private void OnMouseUp()
        {
            _inputLocation.SetLastLocationObject(Input.mousePosition);
            _inputLocation.LoadLocation();

            if (IsInputUI()) return;

            _endPosition = _transform.position;
            Vector3 direction = _startPosition - _endPosition;
            _rigidbody.velocity = -direction.normalized * direction.magnitude;
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