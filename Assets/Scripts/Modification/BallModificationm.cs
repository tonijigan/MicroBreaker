using BallObject;
using Enums;
using UnityEngine;

namespace Modification
{
    public class BallModificationm : ObjectModification
    {
        [SerializeField] private BallEffect _ballEffect;

        public override void SetNewScale(BoosterNames boosterNames, bool isSetBooster)
        {
            ChangeScale(Transform.localScale * GetScaleValue(boosterNames));

            if (isSetBooster == true)
                _ballEffect.SetParticleSystem(boosterNames);
        }

        public override void SetDefultScale(bool isSetBooster)
        {
            ChangeScale(new Vector3(DefultScaleValue, DefultScaleValue, DefultScaleValue));

            if (isSetBooster == true)
                _ballEffect.SetParticleSystem(BoosterNames.Default);
        }
    }
}