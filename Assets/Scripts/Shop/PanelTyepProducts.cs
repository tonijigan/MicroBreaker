using Enums;
using PlayerObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelTyepProducts : Panel
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private Transform _container;
    [SerializeField] private PanelProduct _panelProduct;
    [SerializeField] private Wallet _wallet;

    private ProductView _currentProductView;
    private readonly List<ProductView> _products = new();

    private void Start()
    {
        SetAccess();
        _currentProductView = _products.First();

    }

    public void Create(ProductView productView, Template template)
    {
        ProductView newProductView = Instantiate(productView, _container);
        newProductView.Init(template.name, template.Price, _panelProduct);
        _products.Add(newProductView);
    }

    private void OnEnable()
    {
        _panelProduct.Buyed += OnShowProduct;
        _panelProduct.Buyed += SetAccess;

        foreach (var product in _products)
        {
            product.Selected += SetCurrentProduct;
        }
    }

    private void OnDisable()
    {
        _panelProduct.Buyed -= OnShowProduct;
        _panelProduct.Buyed -= SetAccess;

        foreach (var product in _products)
        {
            product.Selected -= SetCurrentProduct;
        }
    }

    private void SetAccess()
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i].IsBuy == false) _products[i].SetCanBuy(false);
            else _products[i].SetCanBuy(true);
        }
    }

    private void SetCurrentProduct(ProductView productView)
    {
        foreach (var product in _products)
        {
            product.SetStatusOfTheSelected(false);
        }

        productView.SetStatusOfTheSelected(true);
    }

    private void OnShowProduct()
    {
        string name = _products.Where(product => product.IsBuy == true).Select(product => product.Name).FirstOrDefault();
        Debug.Log(name);
    }
}