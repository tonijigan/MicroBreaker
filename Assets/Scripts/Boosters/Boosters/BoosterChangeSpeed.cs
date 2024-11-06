using BallObject;
using Boosters;
using Enums;
using UnityEngine;

public class BoosterChangeSpeed : AbstractBooster
{
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private BallEffect _ballEffect;

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetMaxSpeed();
        _ballEffect.SetParticleSystem(BoosterNames.Negative);
        boosterEffect.SetActionActive();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _ballMovement.SetStandartSpeed();
        _ballEffect.SetParticleSystem(BoosterNames.Default);
        boosterEffect.SetActionActive();
    }
}