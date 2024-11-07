using Enums;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUpgrade : Panel
{
    [SerializeField] private Panel _backGround;
    [SerializeField] private Transform _upgradeViewContainer;
    [SerializeField] private PanelBuyUpgrade _panelBuyUpgrade;
    [SerializeField] private List<ButtonUpgrade> _buttonUpgrades;
    [SerializeField] private Image _image;

    private UpgradeView[] _upgradeViews;
    private ImageUpgradeView _imageUpgradeView;

    private void OnEnable()
    {
        foreach (var upgradeView in _upgradeViews)
            upgradeView.UpgradeClicked += OpenBuyCanUpgrade;

        foreach (var buttonUpgrade in _buttonUpgrades)
            buttonUpgrade.Upgraded += OnClick;
    }

    private void OnDisable()
    {
        foreach (var upgradeView in _upgradeViews)
            upgradeView.UpgradeClicked -= OpenBuyCanUpgrade;

        foreach (var buttonUpgrade in _buttonUpgrades)
            buttonUpgrade.Upgraded -= OnClick;
    }

    private void OnClick(ImageUpgradeView imageUpgradeView)
    {
        _imageUpgradeView = imageUpgradeView;
        _image.sprite = _imageUpgradeView.Sprite;

        for (int i = 0; i < _upgradeViews.Length; i++)
            _upgradeViews[i].Init(_image.sprite);
    }

    protected override void InitAwake()
    {
        _upgradeViews = new UpgradeView[_upgradeViewContainer.childCount];

        for (int i = 0; i < _upgradeViews.Length; i++)
        {
            _upgradeViewContainer.GetChild(i).TryGetComponent(out UpgradeView upgradeView);
            _upgradeViews[i] = upgradeView;
        }
        base.InitAwake();
    }

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    private void OpenBuyCanUpgrade(UpgradeView upgradeView)
    {
        _panelBuyUpgrade.Move(true);
    }
}