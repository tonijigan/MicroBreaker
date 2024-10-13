using System.Collections.Generic;
using UnityEngine;

public abstract class PanelProducts : MonoBehaviour
{
    [SerializeField] private Transform container;

    private readonly List<Product> _products = new();

    public void Create(Product product)
    {
        Product newProduct = Instantiate(product, container);
        _products.Add(newProduct);
    }
}