using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private ContainerLocationObjects _containerLocationObjects;
    [SerializeField] private Transform _transformPoint;
    [SerializeField] private SwipeMove _swipeMove;

    private void OnEnable() => _containerLocationObjects.Filled += SetDistance;

    private void OnDisable() => _containerLocationObjects.Filled -= SetDistance;

    private void SetDistance(LocationObject locationObject)
    {
        var distance = _swipeMove.transform.position.z - locationObject.transform.position.z + _transformPoint.transform.position.z;
        _swipeMove.transform.position = new Vector3(_swipeMove.transform.position.x,
                                                    _swipeMove.transform.position.y,
                                                   distance);
    }
}