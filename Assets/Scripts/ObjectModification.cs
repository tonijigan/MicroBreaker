using Enums;
using UnityEngine;

public abstract class ObjectModification : MonoBehaviour
{
    protected Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    public abstract void ChangeScale(BoosterNames boosterNames);

    protected float GetScaleValue(BoosterNames boosterNames, float valueScale)
    {
        if (boosterNames == BoosterNames.Negative)
            return -valueScale;

        return valueScale;
    }
}