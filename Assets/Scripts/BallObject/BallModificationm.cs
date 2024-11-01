using Enums;
using UnityEngine;

public class BallModificationm : ObjectModification
{
    public override void SetNewScale(BoosterNames boosterNames) => ChangeScale(Transform.localScale * GetScaleValue(boosterNames));

    public override void SetDefultScale() => ChangeScale(new Vector3(DefultScaleValue, DefultScaleValue, DefultScaleValue));
}