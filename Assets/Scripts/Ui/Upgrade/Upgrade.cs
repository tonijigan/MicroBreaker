using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UpgradeView))]
public class Upgrade : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private int _count;

    private UpgradeView _upgradeView;

    public event Action<Upgrade> Clicked;

    public Sprite Sprite { get; private set; }

    public int Price => _price;

    public int Count => _count;

    public UpgradeName UpgradeName { get; private set; }

    public Button Botton => _upgradeView.Button;

    private void Awake() => _upgradeView = GetComponent<UpgradeView>();

    private void OnEnable() => _upgradeView.Button.onClick.AddListener(OnClick);

    private void OnDisable() => _upgradeView.Button.onClick.RemoveListener(OnClick);

    public void Init(Sprite sprite, UpgradeName upgradeName)
    {
        Sprite = sprite;
        UpgradeName = upgradeName;
        _upgradeView.Init(Sprite, _price, _count);
    }

    public void SetState(bool isEnable)
    {
        _upgradeView.SetState(isEnable);
    }

    private void OnClick() => Clicked?.Invoke(this);
}