using Enums;
using UnityEngine;

public class BallModificationm : ObjectModification
{
    public override void SetNewScale(BoosterNames boosterNames) => ChangeScale(GetScaleValue(boosterNames));

    public override void SetDefultScale() => ChangeScale(GetDefultValue());

    private void ChangeScale(float valueScale) => Transform.localScale *= valueScale;
}