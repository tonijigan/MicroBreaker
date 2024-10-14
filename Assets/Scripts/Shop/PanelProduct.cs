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

    private ProductView _productView;

    public void Init(ProductView productView)
    {
        _productView = productView;
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
        Debug.Log(_wallet.Coin);
        Debug.Log(_productView.Price);

        _text.text = _wallet.Coin < _productView.Price ? "Недостаточно средств" : "К покупке готов";

        if (_wallet.Coin < _productView.Price)
        {
            _buttonPay.enabled = false;
            return;
        }

        _buttonPay.enabled = true;
    }

    private void OnListener()
    {
        _wallet.RemoveCoins(_productView.Price);
        _productView.Buy();
        Buyed?.Invoke();
        gameObject.SetActive(false);
    }
}
