using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PanelTyepProducts))]
public class ProductsBallViewCreate : MonoBehaviour
{
    [SerializeField] private ProductBallView _productBallView;
    [SerializeField] private Transform _container;

    private Transform _transform;
    private PanelTyepProducts _panelTyepProducts;
    private readonly List<ProductBallView> _productBallViews = new();

    private void Awake()
    {
        _transform = transform;
        _panelTyepProducts = GetComponent<PanelTyepProducts>();
    }

    private void OnEnable()
    {
        _panelTyepProducts.Inited += CreateProductView;
    }

    private void OnDisable()
    {
        _panelTyepProducts.Inited -= CreateProductView;
    }

    private void CreateProductView(List<Product> products, PanelProduct panelProduct)
    {
        foreach (var product in products)
        {
            ProductBallView productBallView = Instantiate(_productBallView, _container);
            productBallView.Init(panelProduct, product);
            _productBallViews.Add(productBallView);
        }
    }
}