using Enums;
using UnityEngine;

public class PlatfornModification : ObjectModification
{
    private const float FirstUpgradeValue = 0.1f;

    public override void SetNewScale(BoosterNames boosterNames, bool isSetBooster) =>
        ChangeScale(new Vector3(Transform.localScale.x * GetScaleValue(boosterNames), Transform.localScale.y, Transform.localScale.z));

    public override void SetDefultScale(bool isSetBooster) => ChangeScale(new Vector3(DefultScaleValue, DefultScaleValue, DefultScaleValue));

    public void SetUpgradeScale(float scale)
    {
        ChangeScale(new Vector3(Transform.localScale.x * (FirstUpgradeValue * scale), Transform.localScale.y, Transform.localScale.z));
    }
}