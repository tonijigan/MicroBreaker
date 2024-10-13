using UnityEngine;


public class RootSceneGame : Root
{
    [SerializeField] private LocationCreate _locationCreate;

    protected override void OnInit()
    {
        _wallet.Init(_saveService.Coins);
        _locationCreate.Init(_saveService.CurrentLocationName);
    }
}