using System;
using UnityEngine;

public class SaveService : MonoBehaviour
{
    private readonly SaveGameProgress _saveGameProgress = new();

    private GameProgress _gameProgress = new();

    public event Action Loaded;

    public int Coins => _gameProgress.Coins;

    public int LevelCount => _gameProgress.LevelCount;

    public string CurrentLocationName => _gameProgress.CurrentLicationName;

    private void Start() => _saveGameProgress.Load();

    private void OnEnable() => _saveGameProgress.Loaded += OnFill;

    private void OnDisable() => _saveGameProgress.Loaded -= OnFill;

    public int GetCoins()
    {
        return _gameProgress.Coins;
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
        _gameProgress.CurrentLicationName = currentLocationName;
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