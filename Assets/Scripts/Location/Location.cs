using Boosters;
using BoxObject;
using Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxContainer))]
public class Location : MonoBehaviour
{
    [SerializeField] private LocationName _locationName;

    private BoxContainer _boxContainer;

    private void Awake() => _boxContainer = GetComponent<BoxContainer>();

    public string LocationName => _locationName.ToString();

    public BoxContainer BoxContainer => _boxContainer;

    public void Init(BoostersContainer boostersContainer, ParticleSystem particleSystem, Action<List<AbstractBooster>> Created)
    {
        _boxContainer.Fill(boostersContainer, particleSystem, Created);
    }
}