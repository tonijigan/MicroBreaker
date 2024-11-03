using Boosters;
using UnityEngine;

public class BoosterShield : AbstractBooster
{
    [SerializeField] private Transform _shieldObject;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _shieldObject.gameObject.SetActive(false);
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _shieldObject.gameObject.SetActive(true);
    }
}