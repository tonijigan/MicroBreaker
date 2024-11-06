using BallObject;
using Boosters;
using UnityEngine;

public class BoosterChangeSpeed : AbstractBooster
{
    [SerializeField] private BallMovement _ballMovement;

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetMaxSpeed();
        boosterEffect.SetActionActive();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetStandartSpeed();
        boosterEffect.SetActionActive();
    }
}