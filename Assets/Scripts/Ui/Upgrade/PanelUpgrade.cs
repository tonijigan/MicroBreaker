using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelUpgrade : Panel
{
    private const int FirstMultiplier = 1;
    private const int SecondMultiplier = 3;
    private const int ThirdMultiplier = 9;

    [SerializeField] private Panel _backGround;
    [SerializeField] private PanelBuyUpgrade _panelBuyUpgrade;
    [SerializeField] private Image _image;
    [SerializeField] private Upgrade _firstUpgrade;
    [SerializeField] private Upgrade _secondUpgrade;
    [SerializeField] private Upgrade _thirdUpgrate;

    private ButtonUpgrade _currentButtonUpgrade;

    private void OnEnable()
    {
        _firstUpgrade.Clicked += OpenBuyCanUpgrade;
        _secondUpgrade.Clicked += OpenBuyCanUpgrade;
        _thirdUpgrate.Clicked += OpenBuyCanUpgrade;
        _panelBuyUpgrade.Buid += OnSetAccess;
    }

    private void OnDisable()
    {
        _firstUpgrade.Clicked -= OpenBuyCanUpgrade;
        _secondUpgrade.Clicked -= OpenBuyCanUpgrade;
        _thirdUpgrate.Clicked -= OpenBuyCanUpgrade;
        _panelBuyUpgrade.Buid -= OnSetAccess;
    }

    public void Init(ButtonUpgrade buttonUpgrade)
    {
        _currentButtonUpgrade = buttonUpgrade;
        UpgradeTemplate imageUpgrade = _currentButtonUpgrade.UpgradeTemplate;
        _image.sprite = imageUpgrade.Sprite;

        _firstUpgrade.Init(imageUpgrade.Sprite, imageUpgrade.FirstPrice, FirstMultiplier, imageUpgrade.UpgradeName);
        _secondUpgrade.Init(imageUpgrade.Sprite, imageUpgrade.SecondPrice, SecondMultiplier, imageUpgrade.UpgradeName);
        _thirdUpgrate.Init(imageUpgrade.Sprite, imageUpgrade.ThirdPrice, ThirdMultiplier, imageUpgrade.UpgradeName);
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