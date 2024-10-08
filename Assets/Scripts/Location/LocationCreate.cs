using System.Collections.Generic;
using System.Linq;
using Boosters;
using UnityEngine;

public class LocationCreate : MonoBehaviour
{
    [SerializeField] private Save _save;
    [SerializeField] private BoostersContainer _boardsContainer;
    [SerializeField] private List<Location> _locations;

    private Location _currentLocation;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        string locationName = _save.GetName();
        Location newLocation = _locations.Where(location => location.LocationName == locationName).FirstOrDefault();

        if (newLocation == null)
        {
            Debug.Log("Локация не существует");
            return;
        }

        _currentLocation = Instantiate(newLocation, _transform);
        _currentLocation.Init(_boardsContainer);
    }
}