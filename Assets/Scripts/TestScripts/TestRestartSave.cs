using System.Collections.Generic;
using UnityEngine;

public class TestRestartSave : MonoBehaviour
{
    [SerializeField] private SaveService _saveService;

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
            OnClick();
    }

    private void OnClick()
    {
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Ball, "");
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Platform, "");
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Ball, new string[0]);
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Platform, new string[0]);

        _saveService.SaveLocationObjectsNameData(new List<LocationObjectData>(0));
        _saveService.SaveUpgrade(new List<UpgradeValue>(0));
    }
}