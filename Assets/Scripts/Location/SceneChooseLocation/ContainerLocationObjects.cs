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

    private void OnEnable() => _saveService.Loaded += Fill;

    private void OnDisable() => _saveService.Loaded -= Fill;

    private void Fill()
    {
        _locationObjects = new LocationObject[_transform.childCount];

        for (int i = 0; i < _locationObjects.Length; i++)
        {
            _transform.GetChild(i).TryGetComponent(out LocationObject locationObject);
            _locationObjects[i] = locationObject;
        }

        //foreach (var locationObject in _saveService.LocationObjectDatas)
        //{
        //    Debug.Log(locationObject.LocationName + " " + locationObject.Passed);
        //}

        if (_saveService.LocationObjectDatas == null) return;

        List<LocationObject> newLocationObjects = new();

        for (int i = 0; i < _saveService.LocationObjectDatas.Length; i++)
        {
            newLocationObjects.Add(_locationObjects.Where(location => location.Name.ToString() == _saveService.LocationObjectDatas[i].LocationName).FirstOrDefault());
            newLocationObjects[i].SetPassed(true);
            newLocationObjects[i].SetActive();
        }


        var dublicatLocationObjects = _locationObjects.Where(location =>
        location.Name == _locationObjects[newLocationObjects.Count].Name).ToList();

        foreach (var dublicatLocationObject in dublicatLocationObjects)
            dublicatLocationObject.SetActive();

        Filled?.Invoke(dublicatLocationObjects);
    }
}