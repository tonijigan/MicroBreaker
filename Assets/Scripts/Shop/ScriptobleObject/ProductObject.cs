using Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Create Product", order = 52)]
public class ProductObject : ScriptableObject
{
    [SerializeField] private Template _templatePrefab;
    [SerializeField] private int Price;
}