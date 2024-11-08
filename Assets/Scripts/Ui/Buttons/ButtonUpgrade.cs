using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : AbstractButton
{
    [SerializeField] private UpgradeName _upgradeName;
    [SerializeField] private Image _image;
    [SerializeField] private Image _imageBuy;
    [SerializeField] private Image _imageSelected;
    [SerializeField] private PanelUpgrade _panelUpgrade;
    [SerializeField] private List<ImageUpgrade> _imageUpgradeViews;

    public event Action<ButtonUpgrade> UpgradClicked;

    public bool IsBuy { get; private set; } = false;
    public bool IsSelect { get; private set; } = false;

    public UpgradeName UpgradeName => _upgradeName;

    public ImageUpgrade ImageUpgrade { get; private set; }

    protected override void InitAwake()
    {
        base.InitAwake();
        ImageUpgrade = GetCurrentImageUpgrate();
        _image.sprite = ImageUpgrade.Sprite;
        SetState();
    }

    protected override void OnClick()
    {
        if (IsBuy == true)
        {
            SetSelect();
            SetState();
            return;
        }

        _panelUpgrade.gameObject.SetActive(true);
        _panelUpgrade.Move(true);
        UpgradClicked?.Invoke(this);
    }

    public void SetBuy()
    {
        IsBuy = !IsBuy;
        SetSelect();
        SetState();
    }

    private void SetSelect() => IsSelect = !IsSelect;

    private void SetState()
    {
        _imageBuy.gameObject.SetActive(!IsBuy);
        _imageSelected.gameObject.SetActive(IsSelect);
    }

    private ImageUpgrade GetCurrentImageUpgrate()
    {
        return _imageUpgradeViews.Where(image => image.UpgradeName == _upgradeName).FirstOrDefault();
    }
}