using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Test : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private bool _isDragging;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        _isDragging = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isDragging)
        {
            float positionX = Input.GetAxis("Mouse X") * _speed * Time.fixedDeltaTime;
            float positionZ = Input.GetAxis("Mouse Y") * _speed * Time.fixedDeltaTime;

            _rigidbody.AddForce(new Vector3(positionX, _rigidbody.velocity.y, positionZ), ForceMode.Force);

        }
    }
}