using Enums;
using System.Collections.Generic;
using UnityEngine;

public class BoosterHandler : MonoBehaviour
{
    [SerializeField] private AbstractBooster[] _abstractBoostersWhitTimer;
    [SerializeField] private Transform _boosterViewContainer;
    [SerializeField] private BoosterView _boosterViewPrefab;

    private List<AbstractBooster> _abstractBoosters = new();

    private void OnEnable()
    {
        foreach (var abstractBoosterWithTimer in _abstractBoostersWhitTimer)
            abstractBoosterWithTimer.Played += AddBoosterView;

    }

    private void OnDisable()
    {
        foreach (var abstractBoosterWithTimer in _abstractBoostersWhitTimer)
            abstractBoosterWithTimer.Played -= AddBoosterView;
    }

    private void AddBoosterView(Sprite sprite, BoosterNames boosterNames)
    {
        BoosterView boosterView = Instantiate(_boosterViewPrefab, _boosterViewContainer);
        boosterView.Init(sprite, boosterNames);
    }
}