using Boosters;
using PlatformObject;
using UnityEngine;
using Enums;

[RequireComponent(typeof(Rigidbody))]
public abstract class ObjectModification : MonoBehaviour
{
    [SerializeField] private PlatformTrigger _platformTrigger;
    [SerializeField] private ObjectsName _objectsName;

    protected Transform Transform;
    protected Rigidbody Rigidbody;

    private void Awake()
    {
        Transform = transform;
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _platformTrigger.BoosterSended += OnChange;
    }

    private void OnDisable()
    {
        _platformTrigger.BoosterSended -= OnChange;
    }

    private void OnChange(Booster booster, ObjectsName objectsName)
    {
        if (_objectsName == objectsName)
        {

            switch (booster.BoosterName)
            {
                case BoosterNames.Positive:
                    ChangeScale();
                    break;
                case BoosterNames.Negative:
                    ChangeRigidbody();
                    break;
                case BoosterNames.Default:
                    ChangeMesh();
                    break;
                default:
                    break;
            }
        }
    }

    protected abstract void ChangeScale();

    protected abstract void ChangeRigidbody();

    protected abstract void ChangeMesh();
}