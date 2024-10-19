using Enums;
using PlayerObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelTyepProducts : Panel
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private PanelProduct _panelProduct;
    [SerializeField] private Wallet _wallet;

    public event Action<List<Product>, PanelProduct> Inited;

    private Product _currentProduct;
    private SaveService _saveService;
    private List<string> _accessProdoctNames = new();
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void Init(SaveService saveService)
    {
        _saveService = saveService;

        if (_objectsName == ObjectsName.Ball)
        {
            if (_saveService.CurrentBall != "")
                _currentProduct = _products[_products.FindIndex(product => product.Name == _saveService.CurrentBall)];
            else
            {
                _currentProduct = _products.First();
                _saveService.SaveCurrentBall(_currentProduct.Name);
                _accessProdoctNames.Add(_currentProduct.Name);
                _saveService.SaveArrayBalls(_accessProdoctNames.ToArray());
            }

            OpenAccess(_saveService.Balls);
        }

        if (_objectsName == ObjectsName.Platform)
        {
            if (_saveService.CurrentPlatform != "")
                _currentProduct = _products[_products.FindIndex(product => product.Name == _saveService.CurrentPlatform)];
            else
            {
                _currentProduct = _products.First();
                _saveService.SaveCurrentPlatform(_currentProduct.Name);
                _accessProdoctNames.Add(_currentProduct.Name);
                _saveService.SaveArrayPlatforms(_accessProdoctNames.ToArray());
            }

            OpenAccess(_saveService.Platforms);
        }

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

    private void OnEnable()
    {
        _panelProduct.Buyed += OnSaveProductsName;

        foreach (var product in _products)
        {
            product.Selected += SetCurrentProduct;
        }
    }

    private void OnDisable()
    {
        _panelProduct.Buyed -= OnSaveProductsName;

        foreach (var product in _products)
        {
            product.Selected -= SetCurrentProduct;
        }
    }

    private void SetCurrentProduct(Product productSet)
    {
        foreach (var product in _products)
        {
            product.SetStatusOfTheSelected(false);
        }

        productSet.SetStatusOfTheSelected(true);
        _currentProduct = productSet;

        if (_objectsName == ObjectsName.Ball)
            _saveService.SaveCurrentBall(_currentProduct.Name);

        if (_objectsName == ObjectsName.Platform)
            _saveService.SaveCurrentPlatform(_currentProduct.Name);
    }

    private void OnSaveProductsName()
    {
        _accessProdoctNames = _products.Where(product => product.IsBuy == true).Select(product => product.Name).ToList();

        if (_objectsName == ObjectsName.Ball)
            _saveService.SaveArrayBalls(_accessProdoctNames.ToArray());

        if (_objectsName == ObjectsName.Platform)
            _saveService.SaveArrayPlatforms(_accessProdoctNames.ToArray());

        _saveService.SaveCoins(_wallet.Coin);
    }
}