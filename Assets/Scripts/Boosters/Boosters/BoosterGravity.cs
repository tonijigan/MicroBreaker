using BallObject;
using Boosters;
using UnityEngine;

public class BoosterGravity : AbstractBooster
{
    [SerializeField] private BallMovement _ballMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _ballMovement.SetGravity();
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetGravity();
        boosterEffect.SetActionActive();
    }
}