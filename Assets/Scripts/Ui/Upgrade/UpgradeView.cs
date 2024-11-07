using Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private int _level;
    [SerializeField] private int _price;

    public event Action<UpgradeView> UpgradeClicked;

    public int Level => _level;

    public int Price => _price;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        _priceText.text = _price.ToString();
        _levelText.text = $"{_level}x";
    }

    private void OnClick()
    {
        UpgradeClicked?.Invoke(this);
        Debug.Log($"Открыта панель купить прокачку цена - {_price}");
    }
}