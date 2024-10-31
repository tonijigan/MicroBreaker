using Boosters;
using PlatformObject;
using UnityEngine;

public class PlatformSlowingDown : AbstractBooster
{
    private const float Speed = 300;

    [SerializeField] private Platform _platform;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _platform.ChangePlatformSpeed(_platform.PlatformSpeed);
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _platform.ChangePlatformSpeed(Speed);
        boosterEffect.SetActionActive();
    }
}