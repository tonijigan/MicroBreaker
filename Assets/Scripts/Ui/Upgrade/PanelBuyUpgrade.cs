using PlayerObject;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelBuyUpgrade : Panel
{
    [SerializeField] private Panel _backGround;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Image _currentImage;
    [SerializeField] private UpgradeColection _upgradeColection;
    [SerializeField] private Color _firstColor;

    public event Action<Upgrade> Buid;


    private Upgrade _upgrade;

    private void OnEnable() => _buttonBuy.onClick.AddListener(Buy);

    private void OnDisable() => _buttonBuy.onClick.RemoveListener(Buy);

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    public void Init(Upgrade upgrade)
    {
        _upgrade = upgrade;
        SetAccessBuy();
    }

    private void Buy()
    {
        if (_wallet.Coin < _upgrade.Price) return;

        _wallet.RemoveCoins(_upgrade.Price);
        _upgradeColection.SaveUpgrade(_upgrade);
        Move(false);
        Buid?.Invoke(_upgrade);
    }

    private void SetAccessBuy()
    {
        _currentImage.sprite = _upgrade.Sprite;
        _textPrice.text = _upgrade.Price.ToString();

        if (_wallet.Coin < _upgrade.Price)
        {
            _buttonBuy.image.color = Color.red;
            return;
        }

        _buttonBuy.image.color = _firstColor;
    }
}