using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ProductTypeSection), typeof(SwipePanel))]
public class PanelDisplayAllPlatformProducts : MonoBehaviour
{
    [SerializeField] private ChoosePlatform _choosePlatform;
    //[SerializeField] private Button _buttonBuy;
    //[SerializeField] private Button _buttonSelect;
    [SerializeField] private TMP_Text _price;
    //[SerializeField] private Image _imageChoosed;

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
        _swipePanel.Swiped += SetStateProduct;

    }

    private void OnDisable()
    {
        _productTypeSection.Inited -= Create;
        _swipePanel.Swiped -= SetStateProduct;
    }

    public void Create(List<Product> products, PanelProduct panelProduct)
    {
        _products = products;
        _panelProduct = panelProduct;
        _choosePlatform.Init(products);
        _currentProduct = GetCurrentProduct();
        SetStateProduct(_products.IndexOf(_currentProduct));
    }

    private Product GetCurrentProduct()
    {
        return _products.Where(product => product.Name == _choosePlatform.CurrentTemplate.Name).FirstOrDefault();
    }

    private void SetStateProduct(int element)
    {
        _choosePlatform.SetCurrentPlatform(element);
        _currentProduct = GetCurrentProduct();
        _price.text = _currentProduct.Name.ToString();
    }
}