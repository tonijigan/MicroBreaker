using Boosters;
using UnityEngine;

public class BoosterDisableDestruction : AbstractBooster
{
    [SerializeField] private LocationCreate _locationCreate;
    [SerializeField] private BoxesFalling _boxesFalling;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        ActiveCanDestructionBoxs();
        _locationCreate.ActiveCanDestructionBoxs();
        boosterEffect.SetActionActive();
    }

    private void ActiveCanDestructionBoxs()
    {
        if (_boxesFalling.IsActive == false) return;

        foreach (var box in _boxesFalling.Boxes)
            box.SetChangeCanDestruction();
    }
}