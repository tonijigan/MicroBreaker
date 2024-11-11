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

        if (_saveService.LocationObjectDatas == null)
        {
            //Debug.Log("Start");
            //_saveService.SaveLocationObjectsNameData(new List<LocationObjectData>()
            //{ new() { LocationName = _locationObjects[0].Name.ToString(),
            //          Active = _locationObjects[0].IsActive == true ? 1 : 0,
            //          Passed = _locationObjects[0].IsPassed == true ? 1 : 0} });
            return;
        }

        foreach (var item in _saveService.LocationObjectDatas)
        {
            Debug.Log($"{item.LocationName} /A {item.Active} /P {item.Passed}");
        }

        List<LocationObject> newLocationObjects = new();

        for (int i = 0; i < _saveService.LocationObjectDatas.Length; i++)
        {
            newLocationObjects.Add(_locationObjects.Where(location => location.Name.ToString() == _saveService.LocationObjectDatas[i].LocationName).FirstOrDefault());
            newLocationObjects[i].SetPassed(true);
            newLocationObjects[i].SetActive();
        }

        List<LocationObject> identicalLocations = _locationObjects.Where(location => location.Name.ToString().
                                                        Contains(_locationObjects[newLocationObjects.Count].Name.ToString())).ToList();

        foreach (var locationObject in identicalLocations)
        {
            Debug.Log(locationObject.Name);
            locationObject.SetActive();
            newLocationObjects.Add(locationObject);
        }

        List<LocationObjectData> locationObjectDatas = new List<LocationObjectData>();

        for (int i = 0; i < newLocationObjects.Count; i++)
        {
            locationObjectDatas.Add(new LocationObjectData()
            {
                LocationName = newLocationObjects[i].Name.ToString(),
                Active = newLocationObjects[i].IsActive == true ? 1 : 0,
                Passed = newLocationObjects[i].IsPassed == true ? 1 : 0,
            });
        }

        Filled?.Invoke(identicalLocations);
    }
}