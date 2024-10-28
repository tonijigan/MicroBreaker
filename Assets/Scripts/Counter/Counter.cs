using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int Seconds = 60;

    [SerializeField] private LocationCreate _locationCreate;

    public event Action<string> Winned;

    private Location _currentLocation;
    private float _time = 0;
    private int _countLiveBoxs;


    private void OnEnable()
    {
        _locationCreate.Inited += OnInit;
    }

    private void OnDisable()
    {
        _locationCreate.Inited -= OnInit;

        foreach (var box in _currentLocation.BoxContainer.Boxes)
            box.Died -= SetDestroyBox;
    }

    public void UpdateTime()
    {
        _time += Time.deltaTime;
    }

    private void OnInit(Location currentLocation)
    {
        _currentLocation = currentLocation;
        _countLiveBoxs = _currentLocation.BoxContainer.Boxes.Length;

        foreach (var box in _currentLocation.BoxContainer.Boxes)
            box.Died += SetDestroyBox;
    }

    private string GetResultTime()
    {
        return $"{(int)_time / Seconds}:{(int)_time}";
    }

    private void SetDestroyBox()
    {
        _countLiveBoxs--;

        if (_countLiveBoxs <= 0)
            Winned?.Invoke(GetResultTime());
    }
}