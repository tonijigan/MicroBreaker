using BallObject;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private PlatfornModification _platfornModification;
    [SerializeField] private SaveService _saveService;

    private readonly List<UpgradeValue> _upgradeValues = new();

    private void OnEnable() => _saveService.Loaded += Init;

    private void OnDisable() => _saveService.Loaded -= Init;

    private void Init()
    {
        List<UpgradeData> upgradeDatas = _saveService.GetUpgradeData();

        foreach (var upgradeData in upgradeDatas)
            _upgradeValues.Add(new UpgradeValue(upgradeData.UpgradeName, upgradeData.Value, upgradeData.ValueSelect));

        SetObjectUpgrade();
    }

    private void SetObjectUpgrade()
    {
        Debug.Log($"Start: Platform scale = {_platfornModification.Transform.localScale} / Ball ExtraLive = {_ball.ExtraLive}");
        for (int i = 0; i < _upgradeValues.Count; i++)
        {
            if (_upgradeValues[i].UpgradeName == UpgradeName.ExtraLife.ToString() && _upgradeValues[i].Select == true)
            {
                _ball.AddExtraLive(_upgradeValues[i].Value);
            }

            if (_upgradeValues[i].UpgradeName == UpgradeName.Scale.ToString() && _upgradeValues[i].Select == true)
            {
                _platfornModification.SetUpgradeScale(_upgradeValues[i].Value);
            }
        }
        Debug.Log($"SetUpgrade: Platform scale = {_platfornModification.Transform.localScale} / Ball ExtraLive = {_ball.ExtraLive}");
    }
}