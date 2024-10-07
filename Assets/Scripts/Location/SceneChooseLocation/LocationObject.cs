using UnityEngine;
using Enums;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private LocationName _name;

    public LocationName Name => _name;
}