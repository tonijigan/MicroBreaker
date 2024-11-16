using System.Collections.Generic;
using System.Linq;
using BallObject;
using Enums;
using Modification;
using SaveLogic;
using UnityEngine;

namespace UI
{
    public class AdditionalImprovementHandler : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private PlatfornModification _platfornModification;
        [SerializeField] private SaveService _saveService;

        private List<AdditionalImprovementValue> _additionalImprovementValues = new();

        private void OnEnable() => _saveService.Loaded += OnInit;

        private void OnDisable() => _saveService.Loaded -= OnInit;

        private void OnInit()
        {
            _additionalImprovementValues = _saveService.GetAdditionalImprovementValues();
            SetObjectAdditionalImprovement();
        }

        private void SetObjectAdditionalImprovement()
        {
            for (int i = 0; i < _additionalImprovementValues.Count; i++)
            {
                if (_additionalImprovementValues[i].AdditionalImprovementName == AdditionalImprovementName.ExtraLife.ToString() && _additionalImprovementValues[i].IsSelect == true)
                    _ball.AddExtraLive(_additionalImprovementValues[i].Value);

                if (_additionalImprovementValues[i].AdditionalImprovementName == AdditionalImprovementName.Scale.ToString() && _additionalImprovementValues[i].IsSelect == true)
                    _platfornModification.SetAdditionalImprovementScale(_additionalImprovementValues[i].Value);
            }

            _saveService.SaveAdditionalImprovementValues(GetAdditionalImprovementValues());
        }

        private List<AdditionalImprovementValue> GetAdditionalImprovementValues()
        {
            return _additionalImprovementValues.Where(upgradeValues => upgradeValues.IsSelect == false).ToList();
        }
    }
}