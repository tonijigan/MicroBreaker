using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 _offSet;
    private float _positionZ;

    private void OnMouseDown()
    {
        _positionZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Debug.Log(_positionZ);
        _offSet = gameObject.transform.position - GetMousePosition();
        Debug.Log(_offSet);
    }

    private void OnMouseDrag()
    {
        Vector3 direction = GetMousePosition() + _offSet;
        Debug.Log(direction);
        transform.position = new(direction.x, transform.position.y, direction.z);
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, _positionZ));
    }
}