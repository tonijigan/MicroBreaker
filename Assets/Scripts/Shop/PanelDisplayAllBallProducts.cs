using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProductTypeSection))]
public class PanelDisplayAllBallProducts : MonoBehaviour
{
    [SerializeField] private ProductBallView _productBallView;
    [SerializeField] private Transform _container;

    private ProductTypeSection _panelTyepProducts;
    private readonly List<ProductBallView> _productBallViews = new();

    private void Awake() => _panelTyepProducts = GetComponent<ProductTypeSection>();

    private void OnEnable()
    {
        _panelTyepProducts.Inited += CreateProductView;
        _panelTyepProducts.Selected += OnUpdateStates;
        _panelTyepProducts.Buyed += OnUpdateStates;
    }

    private void OnDisable()
    {
        _panelTyepProducts.Inited -= CreateProductView;
        _panelTyepProducts.Selected -= OnUpdateStates;
        _panelTyepProducts.Buyed -= OnUpdateStates;
    }

    private void CreateProductView(List<Product> products, PanelProduct panelProduct)
    {
        foreach (var product in products)
        {
            ProductBallView productBallView = Instantiate(_productBallView, _container);
            productBallView.Init(panelProduct, product);
            _productBallViews.Add(productBallView);
        }

        OnUpdateStates();
    }

    private void OnUpdateStates()
    {
        foreach (var productBallView in _productBallViews)
            productBallView.SetState();
    }
}