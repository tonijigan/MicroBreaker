using Enums;
using UnityEngine;

public class PlatfornModification : ObjectModification
{
    public override void SetNewScale(BoosterNames boosterNames) => ChangeScale(GetScaleValue(boosterNames));

    public override void SetDefultScale() => ChangeScale(GetDefultValue());

    private void ChangeScale(float scaleValue)
    {
        Vector3 scale = new(Transform.localScale.x * scaleValue,
                           transform.localScale.y, transform.localScale.z);
        Transform.localScale = scale;
    }
}