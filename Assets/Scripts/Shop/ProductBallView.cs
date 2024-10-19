using DG.Tweening;
using System;
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
    [SerializeField] private Transform _pointTemplate;

    private PanelProduct _panelProduct;
    private Button _buttonChoose;
    private Product _product;

    private void Awake()
    {
        _buttonChoose = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _buttonChoose.onClick.AddListener(OnSelected);
        _buttonPay.onClick.AddListener(OnOpenBuyPanel);
    }

    private void OnDisable()
    {
        _buttonChoose.onClick.RemoveListener(OnSelected);
        _buttonPay.onClick.RemoveListener(OnOpenBuyPanel);
    }

    public void Init(PanelProduct panelProduct, Product product)
    {
        _product = product;
        _name.text = product.Name;
        _price.text = product.Price.ToString();
        _panelProduct = panelProduct;
    }

    public void SetCanBuy(bool canChoose)
    {
        if (canChoose == false && _product.IsBuy == false)
        {
            StateBlock(canChoose);
            return;
        }

        StateBlock(canChoose);

        if (_product.IsBuy == true)
        {
            _buttonPay.gameObject.SetActive(false);
        }
    }

    private void StateBlock(bool canChoose)
    {
        _buttonChoose.enabled = canChoose;
        _imageBlock.gameObject.SetActive(!canChoose);
    }

    private void OnSelected()
    {
        _product.SetStatusOfTheSelected(true);
    }

    public void SetStatusOfTheSelected(bool isSelected)
    {
        _imageChoosed.gameObject.SetActive(isSelected);
    }

    private void OnOpenBuyPanel()
    {
        _panelProduct.gameObject.SetActive(true);
        _panelProduct.Init(_product);
    }
}