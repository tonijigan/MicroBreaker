using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Template[] _templates;
    [SerializeField] private PanelTyepProducts _panelCreateBallProducts;
    [SerializeField] private PanelTyepProducts _panelCreatePlatformProducts;
    [SerializeField] private SaveService _saveService;

    private readonly List<Product> _products = new();

    private void OnEnable()
    {
        _saveService.Loaded += Create;
    }

    private void OnDisable()
    {
        _saveService.Loaded -= Create;
    }

    private void Create()
    {
        _templates = _templates.OrderBy(template => template.Price).ToArray();

        foreach (var template in _templates)
            _products.Add(new Product(template));

        foreach (var product in _products)
        {
            Debug.Log(product.Name);
            if (product.Template.ObjectsName == Enums.ObjectsName.Ball)
                _panelCreateBallProducts.AddProduct(product);

            if (product.Template.ObjectsName == Enums.ObjectsName.Platform)
                _panelCreatePlatformProducts.AddProduct(product);
        }

        _panelCreateBallProducts.Init(_saveService);
        _panelCreatePlatformProducts.Init(_saveService);
    }
}