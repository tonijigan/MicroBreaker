using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProductView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _buttonPay;
    [SerializeField] private Image _imageChoosed;
    [SerializeField] private Image _imageBlock;

    public event Action Selected;

    private PanelProduct _panelProduct;
    private Button _buttonChoose;

    public string Name { get; private set; }

    public int Price { get; private set; }

    public bool IsBuy { get; private set; } = false;

    public bool IsSelected { get; private set; } = false;

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

    public void Init(string name, int price, PanelProduct panelProduct)
    {
        Name = name;
        Price = price;
        _name.text = name;
        _price.text = price.ToString();
        _panelProduct = panelProduct;
    }

    public void SetCanBuy(bool canChoose)
    {
        if (canChoose == false && IsBuy == false)
        {
            StateBlock(canChoose);
            return;
        }

        StateBlock(canChoose);

        if (IsBuy == true)
        {
            _buttonPay.gameObject.SetActive(false);
        }
    }

    private void StateBlock(bool canChoose)
    {
        _buttonChoose.enabled = canChoose;
        _imageBlock.gameObject.SetActive(!canChoose);
    }

    public void Buy()
    {
        IsBuy = true;
    }

    private void OnSelected()
    {
        IsSelected = true;
        Selected?.Invoke();
    }

    public void StatusOfTheSelected(bool isSelected)
    {
        _imageChoosed.gameObject.SetActive(isSelected);
    }

    private void OnOpenBuyPanel()
    {
        _panelProduct.gameObject.SetActive(true);
        _panelProduct.Init(this);
    }
}