using Boosters;
using UnityEngine;

public class PlatformAddInverted : AbstractBooster
{
    [SerializeField] private PlatformMovement _platformMovement;
    [SerializeField] private PlatformInverted _platformInverted;

    private PlatformMovement _platformMovementClone;

    public bool IsAction { get; private set; } = false;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (IsAction == false) return;

        _platformMovementClone.gameObject.SetActive(false);
        boosterEffect.SetActionActive();
        IsAction = false;
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        IsAction = true;

        if (_platformInverted.IsAction == true)
            _platformInverted.StopAction(boosterEffect);

        _platformMovementClone = Instantiate(_platformMovement, transform);
        _platformMovementClone.EnableInverted();
        _platformMovementClone.transform.GetChild(0).TryGetComponent(out ChangeTemplate changeTemplateClone);
        _platformMovement.transform.GetChild(0).TryGetComponent(out ChangeTemplate changeTemplate);
        changeTemplateClone.EnableCurrentTemplate(changeTemplate.CurrentTemplate.Name, 0);
        boosterEffect.SetActionActive();
    }
}