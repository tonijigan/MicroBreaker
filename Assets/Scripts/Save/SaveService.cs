using Enums;
using System;
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

        return "";
    }

    public string[] GetArrayProducts(ObjectsName objectsName)
    {
        if (objectsName == ObjectsName.Ball)
            return Balls;
        if (objectsName == ObjectsName.Platform)
            return Platforms;

        return new string[0];
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
        Debug.Log(_gameProgress.LocationNames.Length);
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