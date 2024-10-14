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
    private SaveService _saveService;
    private List<string> _accessPrudoctNames = new();
    private readonly List<ProductView> _products = new();

    public void Init(SaveService saveService)
    {
        _saveService = saveService;

        if (_objectsName == ObjectsName.Ball)
        {
            if (_saveService.CurrentBall != "")
                _currentProductView = _products[_products.FindIndex(product => product.Name == _saveService.CurrentBall)];
            else
            {
                _currentProductView = _products.First();
                _saveService.SaveCurrentBall(_currentProductView.Name);
                _accessPrudoctNames.Add(_currentProductView.Name);
                _saveService.SaveArrayBalls(_accessPrudoctNames.ToArray());
            }

            OpenAccess(_saveService.Balls);
        }

        if (_objectsName == ObjectsName.Platform)
        {
            if (_saveService.CurrentPlatform != "")
                _currentProductView = _products[_products.FindIndex(product => product.Name == _saveService.CurrentPlatform)];
            else
            {
                _currentProductView = _products.First();
                _saveService.SaveCurrentPlatform(_currentProductView.Name);
                _accessPrudoctNames.Add(_currentProductView.Name);
                _saveService.SaveArrayPlatforms(_accessPrudoctNames.ToArray());
            }

            OpenAccess(_saveService.Platforms);
        }

        _currentProductView.SetCanBuy(true);
        _currentProductView.Buy();
        SetCurrentProduct(_currentProductView);
        SetAccess();
        gameObject.SetActive(false);
    }

    private void OpenAccess(string[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            ProductView productView = _products.Where(product => product.Name == names[i]).FirstOrDefault();
            productView.SetCanBuy(true);
            productView.Buy();
        }
    }

    public void Create(ProductView productView, Template template)
    {
        ProductView newProductView = Instantiate(productView, _container);
        newProductView.Init(_panelProduct, template);
        _products.Add(newProductView);
    }

    private void OnEnable()
    {
        _panelProduct.Buyed += OnSaveProductsName;
        _panelProduct.Buyed += SetAccess;

        foreach (var product in _products)
        {
            product.Selected += SetCurrentProduct;
        }
    }

    private void OnDisable()
    {
        _panelProduct.Buyed -= OnSaveProductsName;
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

    private void OnSaveProductsName()
    {
        _accessPrudoctNames = _products.Where(product => product.IsBuy == true).Select(product => product.Name).ToList();

        if (_objectsName == ObjectsName.Ball)
            _saveService.SaveArrayBalls(_accessPrudoctNames.ToArray());

        if (_objectsName == ObjectsName.Platform)
            _saveService.SaveArrayPlatforms(_accessPrudoctNames.ToArray());

        _saveService.SaveCoins(_wallet.Coin);
    }
}