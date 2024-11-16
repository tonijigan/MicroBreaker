using CameraLogic;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterCameraShake : AbstractBooster
    {
        [SerializeField] private CameraShake _cameraMoveShake;

        public override void StopAction(BoosterEffect boosterEffect)
        {
            if (boosterEffect.IsActive == false) return;

            _cameraMoveShake.Stabilize();
            boosterEffect.SetActionActive();
        }

        public override void OnStartAction(BoosterEffect boosterEffect)
        {
            _cameraMoveShake.Destabilize();
            boosterEffect.SetActionActive();
        }
    }
}