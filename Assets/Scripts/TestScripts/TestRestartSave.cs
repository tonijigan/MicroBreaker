using System.Collections.Generic;
using SaveLogic;
using UI;
using UnityEngine;

public class TestRestartSave : MonoBehaviour
{
    [SerializeField] private SaveService _saveService;

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
            OnClick();

        if (Input.GetKey(KeyCode.K))
            _saveService.SaveCoins(1000);
    }

    private void OnClick()
    {
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Ball, "");
        _saveService.SaveCurrentProduct(objectsName: Enums.ObjectsName.Platform, "");
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Ball, new string[0]);
        _saveService.SaveArrayProducts(objectsName: Enums.ObjectsName.Platform, new string[0]);

        _saveService.SaveLevelDatas(new List<LevelData>(0));
        _saveService.SaveAdditionalImprovementValues(new List<AdditionalImprovementValue>(0));
    }
}