using Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScene : MonoBehaviour
{
    private const float MaxDistanceDelta = 50;
    private const float ClampX = 9f;
    private const float ClampYMin = -250;
    private const float ClampYMax = -2;

    [SerializeField] private float _speed = 1000;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private bool _isDragging;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _startPosition = Input.mousePosition;
        Debug.Log("Down " + Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        _isDragging = true;
        _currentPosition = Input.mousePosition;
        Debug.Log("OnMouse " + Input.mousePosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }

        Drag();

        RestrictMove();
    }

    private void Drag()
    {
        if (_isDragging)
        {
            float positionX = Input.GetAxis("Mouse X");
            float positionZ = Input.GetAxis("Mouse Y");

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