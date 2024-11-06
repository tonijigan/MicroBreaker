using Boosters;
using UnityEngine;

public class BoosterCameraShake : AbstractBooster
{
    [SerializeField] private CameraMoveShake _cameraMoveShake;

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _cameraMoveShake.Destabilization();
        boosterEffect.SetActionActive();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        boosterEffect.SetActionActive();
    }
}