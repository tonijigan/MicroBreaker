using Boosters;
using UnityEngine;

public class BoosterReset : AbstractBooster
{
    [SerializeField] private BoostersContainer _boostersContainer;

    public override void StopAction(BoosterEffect _) { }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        foreach (var booster in _boostersContainer.AbstractBoosters)
        {
            if (booster.BoosterEffect.IsActive == true)
                booster.StopAction(booster.BoosterEffect);
        }
    }
}