using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdditionalImprovementColection : MonoBehaviour
{
    private const int SelectMaxValue = 1;
    private const int MinValue = 0;

    [SerializeField] private List<ButtonAdditionalImprovement> _buttonAdditionalImprovements;
    [SerializeField] private PanelAdditionalImprovement _panelAdditionalImprovement;
    [SerializeField] private SaveService _saveService;

    private List<AdditionalImprovementValue> _additionalImprovementValues = new();

    private void OnEnable()
    {
        _saveService.Loaded += OnLoadAdditionalImprovement;

        foreach (var upgrade in _buttonAdditionalImprovements)
        {
            upgrade.Clicked += OnClick;
            upgrade.Selected += SaveSelect;
        }
    }

    private void OnDisable()
    {
        _saveService.Loaded -= OnLoadAdditionalImprovement;

        foreach (var upgrade in _buttonAdditionalImprovements)
        {
            upgrade.Clicked -= OnClick;
            upgrade.Selected -= SaveSelect;
        }
    }

    private void OnLoadAdditionalImprovement()
    {
        _additionalImprovementValues = _saveService.GetAdditionalImprovementValues();
        SetStateButtonAdditionalImprovement();
    }

    private void SetStateButtonAdditionalImprovement()
    {
        if (_additionalImprovementValues.Count <= MinValue) return;

        foreach (var additionalImprovementValue in _additionalImprovementValues)
        {
            ButtonAdditionalImprovement buttonAdditionalImprovement = _buttonAdditionalImprovements.Where(button => button.AdditionalImprovementName.ToString() == additionalImprovementValue.AdditionalImprovementName).FirstOrDefault();
            buttonAdditionalImprovement.SetBuy(additionalImprovementValue.IsSelect);
        }
    }

    public void SaveAdditionalImprovement(AdditionalImprovement additionalImprovement)
    {
        _additionalImprovementValues.Add(new(additionalImprovement.AdditionalImprovementName.ToString(), additionalImprovement.Count, SelectMaxValue));
        _saveService.SaveAdditionalImprovementValues(_additionalImprovementValues);
    }

    private void OnClick(ButtonAdditionalImprovement buttonAdditionalImprovement)
    {
        SaveSelect(buttonAdditionalImprovement);
        _panelAdditionalImprovement.gameObject.SetActive(true);
        _panelAdditionalImprovement.Init(buttonAdditionalImprovement);
        _panelAdditionalImprovement.Move(true);
    }

    private void SaveSelect(ButtonAdditionalImprovement buttonAdditionalImprovement)
    {
        if (buttonAdditionalImprovement.IsBuy == false) return;

        AdditionalImprovementValue additionalImprovementValue = _additionalImprovementValues.Where(additionalImprovement => additionalImprovement.AdditionalImprovementName == buttonAdditionalImprovement.AdditionalImprovementName.ToString()).FirstOrDefault();
        additionalImprovementValue.SetSelect(buttonAdditionalImprovement.IsSelect);
        _saveService.SaveAdditionalImprovementValues(_additionalImprovementValues);
    }
}