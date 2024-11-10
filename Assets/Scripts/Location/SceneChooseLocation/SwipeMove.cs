using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class SwipeMove : MonoBehaviour
{
    private const float ClampX = 9f;
    private const float ClampYMin = -600;
    private const float ClampYMax = 10;

    [SerializeField] private LocationChooseInput _inputLocation;
    [SerializeField] private float _speed = 1500;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private bool _isDragging = false;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (IsInputUI())
            return;

        _isDragging = true;
        _startPosition = Input.mousePosition;
        _inputLocation.SetFirstLocationObject(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (_isDragging == true)
            _currentPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        _inputLocation.SetLastLocationObject(Input.mousePosition);
        _inputLocation.LoadLocation();
    }

    private void Update()
    {
        Drag();
        RestrictMove();
    }

    private bool IsInputUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Drag()
    {
        if (_isDragging)
        {
            Vector3 direction = (_currentPosition - _startPosition).normalized;
            Vector3 newDirection = new(direction.x, _rigidbody.velocity.y, direction.y);
            _rigidbody.velocity = newDirection * _speed;
        }
    }

    private void RestrictMove()
    {
        float positionX = Mathf.Clamp(_transform.position.x, -ClampX, ClampX);
        float positionY = Mathf.Clamp(_transform.position.z, ClampYMin, ClampYMax);
        Vector3 clampPosition = new(positionX, _transform.position.y, positionY);
        _transform.position = clampPosition;
    }
}