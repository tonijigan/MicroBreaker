using Boosters;
using UnityEngine;

public class BoosterDisableDestruction : AbstractBooster
{
    [SerializeField] private LocationCreate _locationCreate;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
    }
}