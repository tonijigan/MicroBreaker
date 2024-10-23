using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProductTypeSection))]
public class PanelDisplayAllBallProducts : MonoBehaviour
{
    [SerializeField] private ProductBallView _productBallView;
    [SerializeField] private Transform _container;
    [SerializeField] private SoundButton _soundButton;

    private ProductTypeSection _panelTypeProducts;
    private readonly List<ProductBallView> _productBallViews = new();

    private void Awake() => _panelTypeProducts = GetComponent<ProductTypeSection>();

    private void OnEnable()
    {
        _panelTypeProducts.Inited += CreateProductView;
        _panelTypeProducts.Selected += OnUpdateStates;
        _panelTypeProducts.Buyed += OnUpdateStates;
    }

    private void OnDisable()
    {
        _panelTypeProducts.Inited -= CreateProductView;
        _panelTypeProducts.Selected -= OnUpdateStates;
        _panelTypeProducts.Buyed -= OnUpdateStates;
    }

    private void CreateProductView(List<Product> products, PanelProduct panelProduct)
    {
        foreach (var product in products)
        {
            ProductBallView productBallView = Instantiate(_productBallView, _container);
            productBallView.Init(panelProduct, product, _soundButton.AudioSource);
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