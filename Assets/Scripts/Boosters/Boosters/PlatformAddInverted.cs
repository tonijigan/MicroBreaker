using Boosters;
using UnityEngine;

public class PlatformAddInverted : AbstractBooster
{
    [SerializeField] private PlatformMovement _platformMovement;


    private PlatformMovement _platformMovementClone;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _platformMovementClone.gameObject.SetActive(false);
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _platformMovementClone = Instantiate(_platformMovement, transform);
        _platformMovementClone.EnableInverted();
        boosterEffect.SetActionActive();
    }
}