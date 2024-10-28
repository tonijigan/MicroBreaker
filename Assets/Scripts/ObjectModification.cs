using Enums;
using UnityEngine;

public abstract class ObjectModification : MonoBehaviour
{
    private const float NegativeScaleValue = 0.8f;
    private const float PositiveScaleValue = 1.2f;

    protected Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    public abstract void ChangeScale(BoosterNames boosterNames);

    protected float GetScaleValue(BoosterNames boosterNames)
    {
        Debug.Log(boosterNames);

        if (boosterNames == BoosterNames.Negative)
            return NegativeScaleValue;

        return PositiveScaleValue;
    }
}