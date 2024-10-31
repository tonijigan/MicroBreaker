using Boosters;
using Enums;
using UnityEngine;

public class AddScale : AbstractBooster
{
    [SerializeField] private BallModificationm _ballModification;
    [SerializeField] private PlatfornModification _playformModification;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _playformModification.SetDefultScale();
        _ballModification.SetDefultScale();
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.ObjectsName == ObjectsName.Platform)
            _playformModification.SetNewScale(boosterEffect.BoosterName);

        if (boosterEffect.ObjectsName == ObjectsName.Ball)
            _ballModification.SetNewScale(boosterEffect.BoosterName);

        boosterEffect.SetActionActive();
    }
}