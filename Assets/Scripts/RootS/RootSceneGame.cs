using Enums;
using UnityEngine;


public class RootSceneGame : Root
{
    [SerializeField] private LocationCreate _locationCreate;
    [SerializeField] private ChangeTemplate _changeTemplateBall;
    [SerializeField] private ChangeTemplate _changeTemplatePlatform;
    [SerializeField] private Counter _counter;

    protected override void OnInit()
    {
        _locationCreate.Init(_saveService.CurrentLocationName);
        _changeTemplateBall.EnableCurrentTemplate(_saveService.GetCurrentProduct(ObjectsName.Ball),
                                                  _saveService.GetScale(ObjectsName.Ball));
        _changeTemplatePlatform.EnableCurrentTemplate(_saveService.GetCurrentProduct(ObjectsName.Platform),
                                                      _saveService.GetScale(ObjectsName.Platform));
        _saveService.SaveScale(false, ObjectsName.Ball);
        _saveService.SaveScale(false, ObjectsName.Platform);
    }

    private void Update()
    {
        _counter.UpdateTime();
    }
}