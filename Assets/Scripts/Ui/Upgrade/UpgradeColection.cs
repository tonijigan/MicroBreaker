using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeColection : MonoBehaviour
{
    private const int SelectMaxValue = 1;
    private const int MinValue = 0;

    [SerializeField] private List<ButtonUpgrade> _buttonUpgrades;
    [SerializeField] private PanelUpgrade _panelUpgrade;
    [SerializeField] private SaveService _saveService;

    private List<UpgradeValue> _upgradeValues = new();

    private void OnEnable()
    {
        _saveService.Loaded += OnLoadUpgrade;

        foreach (var upgrade in _buttonUpgrades)
        {
            upgrade.UpgradClicked += OnClick;
            upgrade.Selected += SaveSelect;
        }
    }

    private void OnDisable()
    {
        _saveService.Loaded -= OnLoadUpgrade;

        foreach (var upgrade in _buttonUpgrades)
        {
            upgrade.UpgradClicked -= OnClick;
            upgrade.Selected -= SaveSelect;
        }
    }

    private void OnLoadUpgrade()
    {
        _upgradeValues = _saveService.GetUpgradeValues();
        SetStateButtonUpgrade();
    }

    private void SetStateButtonUpgrade()
    {
        if (_upgradeValues.Count <= MinValue) return;

        foreach (var upgradeValue in _upgradeValues)
        {
            ButtonUpgrade buttonUpgrade = _buttonUpgrades.Where(button => button.UpgradeName.ToString() == upgradeValue.UpgradeName).FirstOrDefault();
            buttonUpgrade.SetBuy(upgradeValue.IsSelect);
        }
    }

    public void SaveUpgrade(Upgrade upgrade)
    {
        _upgradeValues.Add(new(upgrade.UpgradeName.ToString(), upgrade.Count, SelectMaxValue));
        _saveService.SaveUpgrade(_upgradeValues);
    }

    private void OnClick(ButtonUpgrade buttonUpgrade)
    {
        SaveSelect(buttonUpgrade);
        _panelUpgrade.gameObject.SetActive(true);
        _panelUpgrade.Init(buttonUpgrade);
        _panelUpgrade.Move(true);
    }

    private void SaveSelect(ButtonUpgrade buttonUpgrade)
    {
        if (buttonUpgrade.IsBuy == false) return;

        UpgradeValue upgradeValue = _upgradeValues.Where(upgradeObject => upgradeObject.UpgradeName == buttonUpgrade.UpgradeName.ToString()).FirstOrDefault();
        upgradeValue.SetSelect(buttonUpgrade.IsSelect);
        _saveService.SaveUpgrade(_upgradeValues);
    }
}