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

    public void SaveCurrentBall(string currentName)
    {
        _gameProgress.CurrentBall = currentName;
        Save();
        Debug.Log(_gameProgress.CurrentBall);
    }

    public void SaveCurrentPlatform(string currentPlatform)
    {
        _gameProgress.CurrentPlatform = currentPlatform;
        Save();
        Debug.Log(_gameProgress.CurrentPlatform);
    }

    public void SaveArrayBalls(string[] Names)
    {
        _gameProgress.Balls = Names;
        Save();
        Debug.Log(_gameProgress.Balls.Length);
    }

    public void SaveArrayPlatforms(string[] Platforms)
    {
        _gameProgress.Platforms = Platforms;
        Save();
        Debug.Log(_gameProgress.Balls.Length);
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