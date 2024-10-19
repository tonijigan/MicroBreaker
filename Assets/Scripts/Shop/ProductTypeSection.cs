using Enums;
using PlayerObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProductTypeSection : Panel
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private PanelProduct _panelProduct;
    [SerializeField] private Wallet _wallet;

    public event Action<List<Product>, PanelProduct> Inited;
    public event Action Selected;
    public event Action Buyed;

    private Product _currentProduct;
    private SaveService _saveService;
    private List<string> _accessProdoctNames = new();
    private readonly List<Product> _products = new();

    private void OnEnable()
    {
        _panelProduct.Buyed += OnSaveProductsName;

        foreach (var product in _products)
            product.Selected += SetCurrentProduct;
    }

    private void OnDisable()
    {
        _panelProduct.Buyed -= OnSaveProductsName;

        foreach (var product in _products)
            product.Selected -= SetCurrentProduct;
    }

    public void AddProduct(Product product) => _products.Add(product);

    public void Init(SaveService saveService)
    {
        _saveService = saveService;

        if (_saveService.GetCurrentProduct(_objectsName) != "")
            _currentProduct = _products[_products.FindIndex(product => product.Name == _saveService.GetCurrentProduct(_objectsName))];
        else
        {
            _currentProduct = _products.First();
            _saveService.SaveCurrentProduct(_objectsName, _currentProduct.Name);
            _accessProdoctNames.Add(_currentProduct.Name);
            _saveService.SaveArrayProducts(_objectsName, _accessProdoctNames.ToArray());
        }

        OpenAccess(_saveService.GetArrayProducts(_objectsName));
        _currentProduct.Buy();
        SetCurrentProduct(_currentProduct);
        Inited?.Invoke(_products, _panelProduct);
        gameObject.SetActive(false);
    }

    private void OpenAccess(string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Product product = _products.Where(product => product.Name == names[i]).FirstOrDefault();
            product.Buy();
        }
    }

    private void SetCurrentProduct(Product productSet)
    {
        foreach (var product in _products)
            product.SetStatusOfTheSelected(false);

        productSet.SetStatusOfTheSelected(true);
        _currentProduct = productSet;
        _saveService.SaveCurrentProduct(_objectsName, _currentProduct.Name);
        Selected?.Invoke();
    }

    private void OnSaveProductsName()
    {
        _accessProdoctNames = _products.Where(product => product.IsBuy == true).Select(product => product.Name).ToList();
        _saveService.SaveArrayProducts(_objectsName, _accessProdoctNames.ToArray());
        _saveService.SaveCoins(_wallet.Coin);
        Buyed?.Invoke();
    }
}