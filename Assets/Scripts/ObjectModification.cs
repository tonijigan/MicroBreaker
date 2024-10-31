using Enums;
using UnityEngine;

public abstract class ObjectModification : MonoBehaviour
{
    private const float NegativeScaleValue = 0.8f;
    private const float PositiveScaleValue = 1.2f;

    private float DefultScaleValue;
    protected Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
        DefultScaleValue = Transform.localScale.x;
    }

    public abstract void SetNewScale(BoosterNames boosterNames);

    public abstract void SetDefultScale();

    protected float GetScaleValue(BoosterNames boosterNames)
    {
        if (boosterNames == BoosterNames.Negative)
            return NegativeScaleValue;

        return PositiveScaleValue;
    }

    protected float GetDefultValue()
    {
        return DefultScaleValue;
    }
}