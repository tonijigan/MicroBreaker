using Enums;
using UnityEngine;

public class Template : MonoBehaviour
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private int _price;

    public ObjectsName ObjectsName => _objectsName;
    public int Price => _price;
}
