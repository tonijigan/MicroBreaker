using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Vector3 _currentDirection;
    private Transform _transform;
    private float _gravity = -9.8f;
    private float _groundGravity = -0.5f;
    private float _directionY;

    private float _maxJumpTime;

    private void Start()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _directionY = _groundGravity;
    }

    private void Update()
    {
        Jump();
        Move();
        RotationLookAt();
        MoveGravity();
    }

    private void Move()
    {
        _currentDirection = new Vector3(Input.GetAxis("Horizontal"), _directionY, Input.GetAxis("Vertical"));
        _characterController.Move(_speed * Time.deltaTime * _currentDirection);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _directionY = 2;
        }
    }

    private void RotationLookAt()
    {

        if (_currentDirection.x != 0 || _currentDirection.z != 0)
        {
            Vector3 positionLookAt;
            positionLookAt.x = _currentDirection.x;
            positionLookAt.y = 0;
            positionLookAt.z = _currentDirection.z;
            Quaternion targetRotationLookAt = Quaternion.LookRotation(positionLookAt);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotationLookAt, _speed * Time.deltaTime);
        }
    }

    private void MoveGravity()
    {
        if (_characterController.isGrounded)
        {
            _directionY = _groundGravity;
        }
        else
        {
            float previosYVelosity = _currentDirection.y;
            float newYVelosity = _currentDirection.y + (_gravity * Time.deltaTime);
            float nextYVelosity = (previosYVelosity + newYVelosity) * 0.5f;
            _directionY = nextYVelosity;
        }
    }
}