using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelAdditionalImprovement : Panel
{
    private const int FirstMultiplier = 1;
    private const int SecondMultiplier = 3;
    private const int ThirdMultiplier = 9;

    [SerializeField] private Panel _backGround;
    [SerializeField] private PanelBuyAdditionalImprovement _panelBuyUpgrade;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AdditionalImprovement _firstUpgrade;
    [SerializeField] private AdditionalImprovement _secondUpgrade;
    [SerializeField] private AdditionalImprovement _thirdUpgrate;

    private ButtonAdditionalImprovement _currentButtonUpgrade;

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

    public void Init(ButtonAdditionalImprovement buttonUpgrade)
    {
        _currentButtonUpgrade = buttonUpgrade;
        AdditionalImprovementTemplate imageUpgrade = _currentButtonUpgrade.AdditionalImprovementTemplate;
        _image.sprite = imageUpgrade.Sprite;
        _text.text = buttonUpgrade.AdditionalImprovementTemplate.Description;

        _firstUpgrade.Init(imageUpgrade.Sprite, imageUpgrade.FirstPrice, FirstMultiplier, imageUpgrade.AdditionalImprovementName);
        _secondUpgrade.Init(imageUpgrade.Sprite, imageUpgrade.SecondPrice, SecondMultiplier, imageUpgrade.AdditionalImprovementName);
        _thirdUpgrate.Init(imageUpgrade.Sprite, imageUpgrade.ThirdPrice, ThirdMultiplier, imageUpgrade.AdditionalImprovementName);
    }

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    private void OnSetAccess(AdditionalImprovement upgrade)
    {
        upgrade.SetState(false);
        _currentButtonUpgrade.SetBuy(true);
        Move(false);
    }

    private void OpenBuyCanUpgrade(AdditionalImprovement upgrade)
    {
        _panelBuyUpgrade.gameObject.SetActive(true);
        _panelBuyUpgrade.Init(upgrade);
        _panelBuyUpgrade.Move(true);
    }
}