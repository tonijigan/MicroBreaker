using Enums;
using UnityEngine;

public class Template : MonoBehaviour
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private string _templateName;
    [SerializeField] private int _price;

    public ObjectsName ObjectsName => _objectsName;

    public string Name => _templateName;

    public int Price => _price;
}