using Enums;
using UnityEngine;

public class PlatfornModification : ObjectModification
{
    public override void SetNewScale(BoosterNames boosterNames) =>
        ChangeScale(new Vector3(Transform.localScale.x * GetScaleValue(boosterNames), Transform.localScale.y, Transform.localScale.z));

    public override void SetDefultScale() => ChangeScale(new Vector3(DefultScaleValue, DefultScaleValue, DefultScaleValue));
}