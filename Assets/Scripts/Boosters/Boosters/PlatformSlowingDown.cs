using Boosters;
using UnityEngine;

public class PlatformSlowingDown : AbstractBooster
{
    private const float Speed = 300;

    [SerializeField] private PlatformMovement _platformMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _platformMovement.ChangePlatformSpeed(_platformMovement.PlatformSpeed);
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _platformMovement.ChangePlatformSpeed(Speed);
        boosterEffect.SetActionActive();
        PlayTimer(5, boosterEffect, StopAction);
    }
}