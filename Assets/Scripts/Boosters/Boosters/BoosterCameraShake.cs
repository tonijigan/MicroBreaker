using Boosters;
using UnityEngine;

public class BoosterCameraShake : AbstractBooster
{
    [SerializeField] private CameraShake _cameraMoveShake;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _cameraMoveShake.Stabilization();
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _cameraMoveShake.Destabilization();
        boosterEffect.SetActionActive();
    }
}