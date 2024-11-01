using BallObject;
using Boosters;
using UnityEngine;

public class BoosterGravity : AbstractBooster
{
    [SerializeField] private BallMovement _ballMovement;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetGravity();
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetGravity();
        boosterEffect.SetActionActive();
    }
}