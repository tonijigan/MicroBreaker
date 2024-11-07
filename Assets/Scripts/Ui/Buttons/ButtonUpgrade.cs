using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : AbstractButton
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private UpgradeName _upgradeName;
    [SerializeField] private Image _image;
    [SerializeField] private PanelUpgrade _panelUpgrade;
    [SerializeField] private List<ImageUpgradeView> _imageUpgradeViews;

    public event Action<ImageUpgradeView> Upgraded;

    private ImageUpgradeView _currentImageUpgradeView;

    protected override void InitAwake()
    {
        base.InitAwake();
        _currentImageUpgradeView = GetCurrentImageUpgrate();
        _image.sprite = _currentImageUpgradeView.Sprite;
    }

    protected override void OnClick()
    {
        _panelUpgrade.gameObject.SetActive(true);
        _panelUpgrade.Move(true);
        Upgraded?.Invoke(_currentImageUpgradeView);
    }

    private ImageUpgradeView GetCurrentImageUpgrate()
    {
        return _imageUpgradeViews.Where(image => image.ObjectsName == _objectsName && image.UpgradeName == _upgradeName).FirstOrDefault();
    }
}