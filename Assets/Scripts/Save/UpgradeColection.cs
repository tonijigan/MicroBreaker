using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeColection : MonoBehaviour
{
    private const int SelectMaxValue = 1;
    private const int SelectMinValue = 0;

    [SerializeField] private List<ButtonUpgrade> _buttonUpgrades;
    [SerializeField] private PanelUpgrade _panelUpgrade;
    [SerializeField] private SaveService _saveService;

    private List<UpgradeSave> _upgradeList = new();

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
        _upgradeList = _saveService.GetUpgradeSave();
        SetStateButtonUpgrade();
    }

    private void SetStateButtonUpgrade()
    {
        if (_upgradeList.Count <= 0) return;
        Debug.Log("LOG");
        foreach (var upgrade in _upgradeList)
        {
            ButtonUpgrade buttonUpgrade = _buttonUpgrades.Where(button => button.UpgradeName.ToString() == upgrade.UpgradeName).FirstOrDefault();
            buttonUpgrade.SetBuy();
        }
    }

    public void SaveUpgrade(Upgrade upgrade)
    {
        _upgradeList.Add(new()
        {
            UpgradeName = upgrade.UpgradeName.ToString(),
            Value = upgrade.Count,
            ValueSelect = SelectMaxValue
        });
        _saveService.SaveUpgrade(_upgradeList.ToArray());
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

        UpgradeSave upgrade = _upgradeList.Where(upgradeObject => upgradeObject.UpgradeName == buttonUpgrade.UpgradeName.ToString()).FirstOrDefault();
        upgrade.ValueSelect = buttonUpgrade.IsSelect ? SelectMaxValue : SelectMinValue;
        _saveService.SaveUpgrade(_upgradeList.ToArray());
    }
}