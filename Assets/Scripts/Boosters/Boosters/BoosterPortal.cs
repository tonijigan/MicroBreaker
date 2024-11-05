using Boosters;
using UnityEngine;

public class BoosterPortal : AbstractBooster
{
    [SerializeField] private Portal _portal;
    [SerializeField] private TriggerLoss _triggerLoss;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _portal.Open(false);
        _triggerLoss.Collider.enabled = true;
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _portal.Open(true);
        _triggerLoss.Collider.enabled = false;
        boosterEffect.SetActionActive();
    }
}