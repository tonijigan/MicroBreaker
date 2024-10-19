using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProductBallView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _buttonPay;
    [SerializeField] private Image _imageChoosed;
    [SerializeField] private Image _imageBlock;

    private PanelProduct _panelProduct;
    private Product _product;
    private Button _buttonChoose;

    private void Awake() => _buttonChoose = GetComponent<Button>();

    private void OnEnable()
    {
        _buttonChoose.onClick.AddListener(OnClick);
        _buttonPay.onClick.AddListener(OnOpenBuyPanel);
    }

    private void OnDisable()
    {
        _buttonChoose.onClick.RemoveListener(OnClick);
        _buttonPay.onClick.RemoveListener(OnOpenBuyPanel);
    }

    public void Init(PanelProduct panelProduct, Product product)
    {
        _product = product;
        _name.text = product.Name;
        _price.text = product.Price.ToString();
        _panelProduct = panelProduct;
    }

    public void SetState()
    {
        _imageBlock.gameObject.SetActive(!_product.IsBuy);
        _buttonPay.gameObject.SetActive(!_product.IsBuy);

        if (_product.Price == 0)
            _buttonPay.gameObject.SetActive(false);

        _imageChoosed.gameObject.SetActive(_product.IsSelected);
        _buttonChoose.enabled = _product.IsBuy;
    }

    private void OnClick() => _product.Select();

    private void OnOpenBuyPanel()
    {
        _panelProduct.gameObject.SetActive(true);
        _panelProduct.Init(_product);
    }
}