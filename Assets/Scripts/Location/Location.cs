using Boosters;
using BoxObject;
using Enums;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] private LocationName _locationName;
    [SerializeField] private BoxContainer _boxContainer;

    public string LocationName => _locationName.ToString();

    public void Init(BoostersContainer boostersContainer)
    {
        _boxContainer.Fill(boostersContainer);
    }
}