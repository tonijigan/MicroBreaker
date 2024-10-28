using Enums;
using UnityEngine;

public class PlatfornModification : ObjectModification
{
    public override void ChangeScale(BoosterNames boosterNames)
    {
        Vector3 scale = new(Transform.localScale.x * GetScaleValue(boosterNames),
                            transform.localScale.y, transform.localScale.z);
        Transform.localScale = scale;
    }
}