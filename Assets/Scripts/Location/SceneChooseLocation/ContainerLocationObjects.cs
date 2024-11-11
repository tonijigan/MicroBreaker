using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerLocationObjects : MonoBehaviour
{
    [SerializeField] private SaveService _saveService;

    public event Action<List<LocationObject>> Filled;

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
            foreach (var item in _saveService.LocationNames)
            {
                Debug.Log(item);
            }

            List<LocationObject> locationObjects = new();

            for (int i = 0; i < _saveService.LocationNames.Length; i++)
            {
                locationObjects.Add(_locationObjects.Where(location => location.Name.ToString() == _saveService.LocationNames[i]).FirstOrDefault());
                locationObjects[i].SetPassed(true);
                locationObjects[i].SetActive();
            }

            List<LocationObject> identicalLocations = _locationObjects.Where(location => location.Name.ToString().
                                                            Contains(_locationObjects[locationObjects.Count].Name.ToString())).ToList();

            foreach (LocationObject identicalLocation in identicalLocations)
                identicalLocation.SetActive();

            Filled?.Invoke(identicalLocations);
        }
    }
}