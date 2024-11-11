using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    private readonly SaveGameProgress _saveGameProgress = new();

    private GameProgress _gameProgress = new();

    public event Action Loaded;

    public int Coins => _gameProgress.Coins;

    public string CurrentBall => _gameProgress.CurrentBall;

    public string CurrentPlatform => _gameProgress.CurrentPlatform;

    public string[] Balls => _gameProgress.Balls;

    public string[] Platforms => _gameProgress.Platforms;

    public string[] LocationNames => _gameProgress.LocationNames;

    public int LevelCount => _gameProgress.LevelCount;

    public string CurrentLocationName => _gameProgress.CurrentLocationName;

    private void Start() => _saveGameProgress.Load();

    private void OnEnable() => _saveGameProgress.Loaded += OnFill;

    private void OnDisable() => _saveGameProgress.Loaded -= OnFill;

    public int GetCoins()
    {
        return _gameProgress.Coins;
    }

    public string GetCurrentProduct(ObjectsName objectsName)
    {
        if (objectsName == ObjectsName.Ball)
            return CurrentBall;
        if (objectsName == ObjectsName.Platform)
            return CurrentPlatform;

        return string.Empty;
    }

    public string[] GetArrayProducts(ObjectsName objectsName)
    {
        if (objectsName == ObjectsName.Ball)
            return Balls;
        if (objectsName == ObjectsName.Platform)
            return Platforms;

        return new string[0];
    }

    public int GetScale(ObjectsName objectsName)
    {
        int scale = 0;

        if (objectsName == ObjectsName.Ball)
            scale = _gameProgress.ScaleBall;

        if (objectsName == ObjectsName.Platform)
            scale = _gameProgress.ScalePlatform;

        return scale;
    }

    public List<UpgradeValue> GetUpgradeValues()
    {
        List<UpgradeValue> upgradeValues = new();

        for (int i = 0; i < _gameProgress.UpgradeSave.Length; i++)
        {
            upgradeValues.Add(new(_gameProgress.UpgradeSave[i].UpgradeName,
                                  _gameProgress.UpgradeSave[i].Value,
                                  _gameProgress.UpgradeSave[i].ValueSelect));
        }

        return upgradeValues;
    }

    public List<LocationObjectData> GetLocationNamesData()
    {
        return _gameProgress.LocationObjectAccess.ToList();
    }

    public void SaveLocationObjectsNameData(List<LocationObjectData> locationObjectDatas)
    {
        _gameProgress.LocationObjectAccess = locationObjectDatas.ToArray();
        Save();
    }

    public void SaveUpgrade(List<UpgradeValue> upgradeValues)
    {
        List<UpgradeData> upgradeData = new();

        for (int i = 0; i < upgradeValues.Count; i++)
        {
            upgradeData.Add(new UpgradeData()
            {
                UpgradeName = upgradeValues[i].UpgradeName,
                Value = upgradeValues[i].Value,
                ValueSelect = upgradeValues[i].GetSelectValue()
            });
        }

        _gameProgress.UpgradeSave = upgradeData.ToArray();
        Save();
    }

    public void SaveScale(bool isCanScale, ObjectsName objectsName)
    {
        if (objectsName == ObjectsName.Ball)
            _gameProgress.ScaleBall = isCanScale ? 1 : 0;

        if (objectsName == ObjectsName.Platform)
            _gameProgress.ScalePlatform = isCanScale ? 1 : 0;

        Save();
    }

    public void SaveCurrentProduct(ObjectsName objectsName, string currentName)
    {
        if (objectsName == ObjectsName.Ball)
            _gameProgress.CurrentBall = currentName;

        if (objectsName == ObjectsName.Platform)
            _gameProgress.CurrentPlatform = currentName;

        Save();
    }

    public void SaveArrayProducts(ObjectsName objectsName, string[] Names)
    {
        if (objectsName == ObjectsName.Ball)
            _gameProgress.Balls = Names;

        if (objectsName == ObjectsName.Platform)
            _gameProgress.Platforms = Names;

        Save();
    }

    public void SaveArrayLocationNames(string[] LocationNames)
    {
        _gameProgress.LocationNames = LocationNames;
        Save();
    }

    public void SaveCoins(int amount)
    {
        _gameProgress.Coins = amount;
        Save();
    }

    public void SaveLevel(int level)
    {
        _gameProgress.LevelCount = level;
        Save();
    }

    public void SaveCurrentLocationName(string currentLocationName)
    {
        _gameProgress.CurrentLocationName = currentLocationName;
        Save();
    }

    private void Save()
    {
        _saveGameProgress.Save(_gameProgress);
    }

    private void OnFill(GameProgress gameData)
    {
        _gameProgress = gameData;
        Loaded?.Invoke();
    }
}