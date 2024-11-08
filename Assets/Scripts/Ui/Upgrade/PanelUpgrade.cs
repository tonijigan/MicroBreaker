using UnityEngine;
using UnityEngine.UI;

public class PanelUpgrade : Panel
{
    [SerializeField] private Panel _backGround;
    [SerializeField] private Transform _upgradeContainer;
    [SerializeField] private PanelBuyUpgrade _panelBuyUpgrade;
    [SerializeField] private Image _image;

    private Upgrade[] _upgrades;

    private ButtonUpgrade _currentButtonUpgrade;

    private void OnEnable()
    {
        foreach (var upgrade in _upgrades)
            upgrade.Clicked += OpenBuyCanUpgrade;

        _panelBuyUpgrade.Buid += OnSetAccess;
    }

    private void OnDisable()
    {
        foreach (var upgrade in _upgrades)
            upgrade.Clicked -= OpenBuyCanUpgrade;

        _panelBuyUpgrade.Buid -= OnSetAccess;
    }

    public void Init(ButtonUpgrade buttonUpgrade)
    {
        _currentButtonUpgrade = buttonUpgrade;
        ImageUpgrade imageUpgrade = _currentButtonUpgrade.ImageUpgrade;
        _image.sprite = imageUpgrade.Sprite;

        for (int i = 0; i < _upgrades.Length; i++)
            _upgrades[i].Init(imageUpgrade.Sprite, imageUpgrade.UpgradeName);
    }

    protected override void InitAwake()
    {
        _upgrades = new Upgrade[_upgradeContainer.childCount];

        for (int i = 0; i < _upgrades.Length; i++)
        {
            _upgradeContainer.GetChild(i).TryGetComponent(out Upgrade upgrade);
            _upgrades[i] = upgrade;
        }
        base.InitAwake();
    }

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    private void OnSetAccess(Upgrade upgrade)
    {
        upgrade.SetState(false);
        _currentButtonUpgrade.SetBuy();
    }

    private void OpenBuyCanUpgrade(Upgrade upgrade)
    {
        _panelBuyUpgrade.gameObject.SetActive(true);
        _panelBuyUpgrade.Init(upgrade);
        _panelBuyUpgrade.Move(true);
    }
}