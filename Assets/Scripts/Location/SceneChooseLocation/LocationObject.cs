using UnityEngine;
using Enums;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private LocationName _name;
    [SerializeField] private bool _isActive;

    public LocationName Name => _name;

    public bool IsActive => _isActive;
}