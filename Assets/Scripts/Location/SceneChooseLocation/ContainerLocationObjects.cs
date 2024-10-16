using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerLocationObjects : MonoBehaviour
{
    [SerializeField] private SaveService _saveService;

    private Transform _transform;

    private LocationObject[] _locationObjects;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _saveService.Loaded += Fill;
    }

    private void OnDisable()
    {
        _saveService.Loaded -= Fill;
    }

    private void Fill()
    {
        _locationObjects = new LocationObject[_transform.childCount];

        for (int i = 0; i < _locationObjects.Length; i++)
        {
            _transform.GetChild(i).TryGetComponent(out LocationObject locationObject);
            _locationObjects[i] = locationObject;
        }

        if (_saveService.LocationNames != null)
        {
            foreach (var name in _saveService.LocationNames)
            {
                var locationObjects = _locationObjects.Where(location => location.Name.ToString() == name).FirstOrDefault();
                locationObjects.SetPassed(true);
            }
        }
    }
}