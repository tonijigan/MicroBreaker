using System;
using UnityEngine;

public class LocationChooseInput : MonoBehaviour
{
    public event Action<LocationObject> LocationChoosed;

    private LocationObject _firstLocationObject;
    private LocationObject _lastLocationObject;

    public void SetFirstLocationObject(Vector3 inputMouse)
    {
        _firstLocationObject = TryGetLocation(inputMouse);
    }

    public void SetLastLocationObject(Vector3 inputMouse)
    {
        _lastLocationObject = TryGetLocation(inputMouse);
    }

    public void LoadLocation()
    {
        if (_firstLocationObject == null || _lastLocationObject == null)
            return;

        if (_firstLocationObject.name != _lastLocationObject.name)
            return;

        LocationChoosed?.Invoke(_firstLocationObject);
    }

    private LocationObject TryGetLocation(Vector3 inputMouse)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputMouse);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.TryGetComponent(out LocationObject locationObject);
            return locationObject;
        }
        return null;
    }
}