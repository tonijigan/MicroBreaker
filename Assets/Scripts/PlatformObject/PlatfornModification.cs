using Enums;
using UnityEngine;

public class PlatfornModification : ObjectModification
{
    private const float ValueScale = 0.5f;
    public override void ChangeScale(BoosterNames boosterNames)
    {
        Vector3 scale = new(Transform.localScale.x + GetScaleValue(boosterNames, ValueScale),
                            transform.localScale.y, transform.localScale.z);
        Transform.localScale = scale;
    }
}