using System;
using System.Collections.Generic;
using BoosterLogic;
using BoxObject;
using Enums;
using UnityEngine;

namespace LocationLogic
{
    public class Location : MonoBehaviour
    {
        [SerializeField] private LocationName _locationName;
        [SerializeField] private BoxContainer _boxContainer;
        [SerializeField] private string _additionaValue = string.Empty;

        public string LocationName => _locationName.ToString();

        public BoxContainer BoxContainer => _boxContainer;

        public string AdditionaValue => _additionaValue;

        public void Init(BoostersContainer boostersContainer, ParticleSystem particleSystem, Action<List<AbstractBooster>> Created)
        {
            _boxContainer.Fill(boostersContainer, particleSystem, Created);
        }
    }
}