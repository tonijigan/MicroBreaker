using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelProduct : Panel
{
    [SerializeField] private Button _buttonPay;

    public event Action Buyed;

    private ProductView _productView;

    public void Init(ProductView productView)
    {
        _productView = productView;
    }

    private void OnEnable()
    {
        _buttonPay.onClick.AddListener(OnListener);
    }

    private void OnDisable()
    {
        _buttonPay.onClick.RemoveListener(OnListener);
    }

    private void OnListener()
    {
        _productView.Buy();
        Buyed?.Invoke();
        gameObject.SetActive(false);
    }
}
