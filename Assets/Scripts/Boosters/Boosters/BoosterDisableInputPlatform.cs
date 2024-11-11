using Boosters;
using PlatformObject;
using UnityEngine;

public class BoosterDisableInputPlatform : AbstractBooster
{
    private const int WaitSeconds = 2;

    [SerializeField] private InputPointMovement _inputPointMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _inputPointMovement.gameObject.SetActive(true);
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _inputPointMovement.gameObject.SetActive(false);
        boosterEffect.SetActionActive();
        PlayTimer(WaitSeconds, boosterEffect, StopAction);
    }
}