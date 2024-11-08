using UnityEngine;

public class TestRestartSave : AbstractButton
{
    [SerializeField] private SaveService _saveService;

    protected override void OnClick()
    {
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Ball, "");
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Platform, "");
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Ball, new string[0]);
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Platform, new string[0]);
        _saveService.SaveArrayLocationNames(new string[0]);
        _saveService.SaveUpgrade(new UpgradeSave[0]);
    }
}