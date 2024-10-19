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

    public event Action Buyed;

    private Product _product;

    public void Init(Product product)
    {
        _product = product;
        AssignAccess();
    }

    private void OnEnable()
    {
        _buttonPay.onClick.AddListener(OnListener);
    }

    private void OnDisable()
    {
        _buttonPay.onClick.RemoveListener(OnListener);
    }

    private void AssignAccess()
    {
        _text.text = _wallet.Coin < _product.Price ? "Недостаточно средств" : "К покупке готов";

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
        Buyed?.Invoke();
        gameObject.SetActive(false);
    }
}
