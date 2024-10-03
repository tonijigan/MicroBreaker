using UnityEngine;

public class BallTemplate : MonoBehaviour
{
    [SerializeField] private ObjectsName _objectsName;

    public ObjectsName ObjectsName => _objectsName;
}