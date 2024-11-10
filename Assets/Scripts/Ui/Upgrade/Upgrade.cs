using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UpgradeView))]
public class Upgrade : MonoBehaviour
{
    private UpgradeView _upgradeView;

    public event Action<Upgrade> Clicked;

    public Sprite Sprite { get; private set; }

    public int Price { get; private set; }

    public int Count { get; private set; }

    public UpgradeName UpgradeName { get; private set; }

    public Button Botton => _upgradeView.Button;

    private void Awake() => _upgradeView = GetComponent<UpgradeView>();

    private void OnEnable() => _upgradeView.Button.onClick.AddListener(OnClick);

    private void OnDisable() => _upgradeView.Button.onClick.RemoveListener(OnClick);

    public void Init(Sprite sprite, int price, int count, UpgradeName upgradeName)
    {
        Sprite = sprite;
        Price = price;
        Count = count;
        UpgradeName = upgradeName;
        _upgradeView.Init(Sprite, Price, Count);
    }

    public void SetState(bool isEnable) => _upgradeView.SetState(isEnable);

    private void OnClick() => Clicked?.Invoke(this);
}