using Player;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class MoveScene : MonoBehaviour
{
    private const float MaxDistanceDelta = 50;
    private const float ClampX = 9f;
    private const float ClampYMin = -100;
    private const float ClampYMax = 100;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed = 1000;

    private Transform _transform;

    private Vector3 _startSwipePosition;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        // _playerInput.MousePressed += OnMove;
    }


    private void OnDisable()
    {
        //_playerInput.MousePressed -= OnMove;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startSwipePosition = _playerInput.GetPosition();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = (_playerInput.GetPosition() - _startSwipePosition).normalized;
            Debug.Log(currentPosition);
            OnMove(currentPosition, currentPosition);
        }

        RestrictMove();
    }

    private void OnMove(Vector3 position, Vector3 raycastPoint)
    {
        _transform.Translate(_speed * Time.deltaTime * position);
    }

    private void RestrictMove()
    {
        float positionX = Mathf.Clamp(_transform.position.x, -ClampX, ClampX);
        float positionY = Mathf.Clamp(_transform.position.z, ClampYMin, ClampYMax);
        Vector3 clampPosition = new(positionX, _transform.position.y, positionY);
        _transform.position = clampPosition;
    }
}