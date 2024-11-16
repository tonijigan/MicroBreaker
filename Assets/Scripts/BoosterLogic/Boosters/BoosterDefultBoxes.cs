using LocationLogic;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterDefultBoxes : AbstractBooster
    {
        [SerializeField] private LocationCreate _locationCreate;

        public override void StopAction(BoosterEffect boosterEffect)
        {
            if (boosterEffect.IsActive == false) return;

            boosterEffect.SetActionActive();
        }

        public override void OnStartAction(BoosterEffect boosterEffect)
        {
            _locationCreate.SetDefultBox();
            boosterEffect.SetActionActive();
        }
    }
}