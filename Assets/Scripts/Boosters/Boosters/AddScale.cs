using Boosters;
using Enums;
using UnityEngine;

public class AddScale : AbstractBooster
{
    [SerializeField] private BallModificationm _ballModification;
    [SerializeField] private PlatfornModification _playformModification;

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.ObjectsName == ObjectsName.Platform)
            _playformModification.ChangeScale(boosterEffect.BoosterName);

        if (boosterEffect.ObjectsName == ObjectsName.Ball)
            _ballModification.ChangeScale(boosterEffect.BoosterName);
    }
}