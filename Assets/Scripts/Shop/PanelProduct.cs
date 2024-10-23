using DG.Tweening;
using PlayerObject;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PanelProduct : Panel
{
    [SerializeField] private Button _buttonPay;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Panel _backGround;
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

    private RectTransform _rectTransform;

    public event Action Bought;

    private Product _product;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

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
        await MoveButton(isAction);
        _backGround.gameObject.SetActive(isAction);
    }

    public void Init(Product product)
    {
        _product = product;
        AssignAccess();
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
        Bought?.Invoke();
        Move(false);
    }

    private async Task MoveButton(bool isActive)
    {
        Debug.Log(isActive);

        if (isActive)
            await _rectTransform.DOAnchorPosY(_middlePositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_topPositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}