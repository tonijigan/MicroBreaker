using UnityEngine;

public class PlatformTemplate : MonoBehaviour
{
    [SerializeField] private ObjectsName _objectsName;

    public ObjectsName ObjectsName => _objectsName;
}
