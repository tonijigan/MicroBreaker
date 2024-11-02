using Boosters;
using UnityEngine;

public class BoosterDefultBoxes : AbstractBooster
{
    [SerializeField] private LocationCreate _locationCreate;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _locationCreate.SetDefultBox();
        boosterEffect.SetActionActive();
    }
}