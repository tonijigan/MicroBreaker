using System;
using System.Collections.Generic;
using System.Linq;
using BoosterLogic;
using Enums;
using SaveLogic;
using UnityEngine;

namespace LocationLogic
{
    public class LocationCreate : MonoBehaviour
    {
        [SerializeField] private BoostersContainer _boardsContainer;
        [SerializeField] private List<Location> _locations;
        [SerializeField] private ParticleSystem _boxParticleSystem;

        public event Action<Location> Inited;
        public event Action<List<AbstractBooster>> Created;

        private Transform _transform;

        public Location CurrentLocation { get; private set; }

        public void Init(LevelData locationObjectData)
        {
            _transform = transform;
            Location newLocation = _locations.Where(location => location.LocationName == locationObjectData.LocationName &&
                                                    location.AdditionaValue == locationObjectData.AdditionaValue).FirstOrDefault();

            if (newLocation == null) return;

            CurrentLocation = Instantiate(newLocation, _transform);
            CurrentLocation.Init(_boardsContainer, _boxParticleSystem, Created);
            Inited?.Invoke(CurrentLocation);
        }

        public void SetDefultBox()
        {
            foreach (var box in CurrentLocation.BoxContainer.Boxes)
            {
                box.SetName(BoosterNames.Default);
                box.SetStandartHealth();
            }
        }

        public void ActiveCanDestructionBoxs()
        {
            foreach (var box in CurrentLocation.BoxContainer.Boxes)
                box.SetCanDestructuin();
        }
    }
}