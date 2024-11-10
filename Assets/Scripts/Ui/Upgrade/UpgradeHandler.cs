using BallObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private PlatfornModification _platfornModification;
    [SerializeField] private SaveService _saveService;

    private List<UpgradeValue> _upgradeValues = new();

    private void OnEnable() => _saveService.Loaded += Init;

    private void OnDisable() => _saveService.Loaded -= Init;

    private void Init()
    {
        _upgradeValues = _saveService.GetUpgradeValues();
        SetObjectUpgrade();
    }

    private void SetObjectUpgrade()
    {
        Debug.Log($"Start: Platform scale = {_platfornModification.Transform.localScale} / Ball ExtraLive = {_ball.ExtraLive}");
        for (int i = 0; i < _upgradeValues.Count; i++)
        {
            if (_upgradeValues[i].UpgradeName == UpgradeName.ExtraLife.ToString() && _upgradeValues[i].IsSelect == true)
            {
                _ball.AddExtraLive(_upgradeValues[i].Value);
            }

            if (_upgradeValues[i].UpgradeName == UpgradeName.Scale.ToString() && _upgradeValues[i].IsSelect == true)
            {
                _platfornModification.SetUpgradeScale(_upgradeValues[i].Value);
            }
        }

        _saveService.SaveUpgrade(GetUpgradeValues());
        Debug.Log($"SetUpgrade: Platform scale = {_platfornModification.Transform.localScale} / Ball ExtraLive = {_ball.ExtraLive}");
    }

    private List<UpgradeValue> GetUpgradeValues()
    {
        var upgradeValues = _upgradeValues.Where(upgradeValues => upgradeValues.IsSelect == false).ToList();
        return upgradeValues;
    }
}