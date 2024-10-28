using Enums;
using UnityEngine;

public class BallModificationm : ObjectModification
{
    public override void ChangeScale(BoosterNames boosterNames)
    {
        Transform.localScale *= GetScaleValue(boosterNames);
    }
}