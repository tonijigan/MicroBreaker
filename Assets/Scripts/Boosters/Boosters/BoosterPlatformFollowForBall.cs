using Boosters;
using PlatformObject;
using UnityEngine;

public class BoosterPlatformFollowForBall : AbstractBooster
{
    [SerializeField] private PlatformTrigger _platformTrigger;
    [SerializeField] private PlatformMovement _platformMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;
        SetAction(boosterEffect);
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        SetAction(boosterEffect);
        PlayTimer(boosterEffect, StopAction);
    }

    private void SetAction(BoosterEffect boosterEffect)
    {
        _platformTrigger.ChangeStateCollision();
        _platformMovement.ChangeTarget();
        boosterEffect.SetActionActive();
    }
}