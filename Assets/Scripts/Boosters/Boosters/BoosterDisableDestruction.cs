using Boosters;
using UnityEngine;

public class BoosterDisableDestruction : AbstractBooster
{
    [SerializeField] private LocationCreate _locationCreate;
    [SerializeField] private BoxesFalling _boxesFalling;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        ActiveCanDestructionBoxs();
        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
        PlayTimer(5, boosterEffect, StopAction);
    }

    private void ActiveCanDestructionBoxs()
    {
        if (_boxesFalling.IsActive == false) return;

        foreach (var box in _boxesFalling.Boxes)
            box.Rigidbody.isKinematic = !box.Rigidbody.isKinematic;
    }
}