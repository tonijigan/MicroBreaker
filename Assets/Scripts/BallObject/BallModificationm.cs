using Enums;
using UnityEngine;

public class BallModificationm : ObjectModification
{
    private const float ValueScale = 1.2f;
    public override void ChangeScale(BoosterNames boosterNames)
    {
        Transform.localScale *= GetScaleValue(boosterNames, ValueScale);
    }
}