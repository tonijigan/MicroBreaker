using PlatformLogic;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterDisableInputPlatform : AbstractBooster
    {
        [SerializeField] private InputPointMovement _inputPointMovement;

        public override void StopAction(BoosterEffect boosterEffect)
        {
            if (boosterEffect.IsActive == false) return;

            _inputPointMovement.gameObject.SetActive(true);
            boosterEffect.SetActionActive();
        }

        public override void OnStartAction(BoosterEffect boosterEffect)
        {
            _inputPointMovement.gameObject.SetActive(false);
            boosterEffect.SetActionActive();
            PlayTimer(boosterEffect, StopAction);
        }
    }
}