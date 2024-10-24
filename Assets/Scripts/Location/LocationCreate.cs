using System.Collections.Generic;
using System.Linq;
using Boosters;
using UnityEngine;

public class LocationCreate : MonoBehaviour
{
    [SerializeField] private BoostersContainer _boardsContainer;
    [SerializeField] private List<Location> _locations;
    [SerializeField] private ParticleSystem _boxParticleSystem;

    public Location CurrentLocation { get; private set; }
    private Transform _transform;

    public void Init(string locationName)
    {
        _transform = transform;
        Location newLocation = _locations.Where(location => location.LocationName == locationName).FirstOrDefault();

        if (newLocation == null)
        {
            Debug.Log("������� �� ����������");
            return;
        }

        CurrentLocation = Instantiate(newLocation, _transform);
        CurrentLocation.Init(_boardsContainer, _boxParticleSystem);
    }
}