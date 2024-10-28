using PlayerObject;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelProduct : Panel
{
    [SerializeField] private Button _buttonPay;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Panel _backGround;

    public event Action Bought;

    private Product _product;

    private void OnEnable()
    {
        _buttonPay.onClick.AddListener(OnListener);
    }

    private void OnDisable()
    {
        _buttonPay.onClick.RemoveListener(OnListener);
    }

    public override async void Move(bool isAction)
    {
        base.Move(isAction);
        await MovePanel(isAction);
        _backGround.gameObject.SetActive(isAction);
    }

    public void Init(Product product)
    {
        _product = product;
        AssignAccess();
    }

    private void AssignAccess()
    {
        _text.text = _wallet.Coin < _product.Price ? "������������ �������" : "� ������� �����";

        if (_wallet.Coin < _product.Price)
        {
            _buttonPay.enabled = false;
            return;
        }

        _buttonPay.enabled = true;
    }

    private void OnListener()
    {
        _wallet.RemoveCoins(_product.Price);
        _product.Buy();
        Bought?.Invoke();
        Move(false);
    }
}