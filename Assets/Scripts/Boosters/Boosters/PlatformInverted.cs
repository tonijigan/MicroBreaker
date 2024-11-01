using Boosters;
using UnityEngine;

public class PlatformInverted : AbstractBooster
{
    [SerializeField] private PlatformMovement _platformMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _platformMovement.EnableInverted();
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _platformMovement.EnableInverted();
        boosterEffect.SetActionActive();
    }
}