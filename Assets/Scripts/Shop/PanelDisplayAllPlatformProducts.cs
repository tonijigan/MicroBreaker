using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ProductTypeSection), typeof(SwipePanel))]
public class PanelDisplayAllPlatformProducts : MonoBehaviour
{
    [SerializeField] private ChoosePlatform _choosePlatform;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private Button _buttonSelect;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;

    private SwipePanel _swipePanel;
    private PanelProduct _panelProduct;
    private ProductTypeSection _productTypeSection;
    private Product _currentProduct;
    private List<Product> _products = new();

    private void Awake()
    {
        _swipePanel = GetComponent<SwipePanel>();
        _productTypeSection = GetComponent<ProductTypeSection>();
    }

    private void OnEnable()
    {
        _productTypeSection.Inited += Create;
        _productTypeSection.Buyed += OnSetStateProduct;
        _swipePanel.Swiped += OnSetCurrentProduct;
        _buttonBuy.onClick.AddListener(OpenBuyPanel);
        _buttonSelect.onClick.AddListener(Choose);
    }

    private void OnDisable()
    {
        _productTypeSection.Inited -= Create;
        _productTypeSection.Buyed -= OnSetStateProduct;
        _swipePanel.Swiped -= OnSetCurrentProduct;
        _buttonBuy.onClick.RemoveListener(OpenBuyPanel);
        _buttonSelect.onClick.RemoveListener(Choose);
    }

    private void Choose()
    {
        _currentProduct.Select();
        OnSetStateProduct();
    }

    public void Create(List<Product> products, PanelProduct panelProduct)
    {
        _products = products;
        _panelProduct = panelProduct;
        _choosePlatform.Init(products);
        _currentProduct = GetCurrentProduct();
        OnSetStateProduct();
    }

    private Product GetCurrentProduct()
    {
        return _products.Where(product => product.Name == _choosePlatform.CurrentTemplate.Name).FirstOrDefault();
    }

    private void OnSetCurrentProduct(int element)
    {
        _choosePlatform.SetCurrentPlatform(element);
        _currentProduct = GetCurrentProduct();
        OnSetStateProduct();
    }

    private void OnSetStateProduct()
    {
        _name.text = _currentProduct.Name.ToString();
        _price.text = _currentProduct.Price.ToString();
        _buttonBuy.gameObject.SetActive(!_currentProduct.IsBuy);
        _buttonSelect.gameObject.SetActive(_currentProduct.IsBuy);
        _buttonSelect.enabled = !_currentProduct.IsSelected;
    }

    private void OpenBuyPanel()
    {
        _panelProduct.Init(_currentProduct);
        _panelProduct.Move(true);
    }
}