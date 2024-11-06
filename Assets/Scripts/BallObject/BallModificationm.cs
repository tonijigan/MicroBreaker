using BallObject;
using Enums;
using UnityEngine;

public class BallModificationm : ObjectModification
{
    [SerializeField] private BallEffect _ballEffect;

    public override void SetNewScale(BoosterNames boosterNames)
    {
        ChangeScale(Transform.localScale * GetScaleValue(boosterNames));
        _ballEffect.SetParticleSystem(boosterNames);
    }

    public override void SetDefultScale()
    {
        ChangeScale(new Vector3(DefultScaleValue, DefultScaleValue, DefultScaleValue));
        _ballEffect.SetParticleSystem(BoosterNames.Default);
    }
}