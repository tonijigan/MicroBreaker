using Enums;
using UnityEngine;


public class RootSceneGame : Root
{
    [SerializeField] private LocationCreate _locationCreate;
    [SerializeField] private ChangeTemplate _changeTemplateBall;
    [SerializeField] private ChangeTemplate _changeTemplatePlatform;

    protected override void OnInit()
    {
        _locationCreate.Init(_saveService.CurrentLocationName);
        _changeTemplateBall.EnambeCurrentTemplate(_saveService.GetCurrentProduct(ObjectsName.Ball));
        _changeTemplatePlatform.EnambeCurrentTemplate(_saveService.GetCurrentProduct(ObjectsName.Platform));
    }
}