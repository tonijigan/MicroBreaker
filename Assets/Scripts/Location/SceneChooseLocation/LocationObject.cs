using UnityEngine;
using Enums;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private LocationName _name;
    [SerializeField] private bool _isActive;

    public bool IsPassed { get; private set; } = false;

    public LocationName Name => _name;

    public bool IsActive => _isActive;

    public void SetPassed(bool isPassed)
    {
        Debug.Log("Set");
        IsPassed = isPassed;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}