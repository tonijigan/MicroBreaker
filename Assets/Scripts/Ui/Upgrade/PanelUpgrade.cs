using Enums;
using UnityEngine;

public class PanelUpgrade : Panel
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private Panel _backGround;
    [SerializeField] private Transform _upgradeViewContainer;
    [SerializeField] private PanelBuyUpgrade _panelBuyUpgrade;

    private UpgradeView[] _upgradeViews;

    private void OnEnable()
    {
        foreach (var upgradeView in _upgradeViews)
            upgradeView.UpgradeClicked += OpenBuyCanUpgrade;
    }

    private void OnDisable()
    {
        foreach (var upgradeView in _upgradeViews)
            upgradeView.UpgradeClicked -= OpenBuyCanUpgrade;
    }

    protected override void InitAwake()
    {
        base.InitAwake();
        _upgradeViews = new UpgradeView[_upgradeViewContainer.childCount];

        for (int i = 0; i < _upgradeViews.Length; i++)
        {
            _upgradeViewContainer.GetChild(i).TryGetComponent(out UpgradeView upgradeView);
            _upgradeViews[i] = upgradeView;
        }
    }

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    private void OpenBuyCanUpgrade(UpgradeView upgradeView)
    {
        _panelBuyUpgrade.Move(true);
    }
}