using Boosters;
using UnityEngine;

public class BoosterLaserGun : AbstractBooster
{
    [SerializeField] private LaserGun _laserGun;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        _laserGun.enabled = false;
        boosterEffect.SetActionActive();
    }

    protected override void OnStartAction(BoosterEffect boosterEffect)
    {
        _laserGun.Shooting();
        boosterEffect.SetActionActive();
    }
}