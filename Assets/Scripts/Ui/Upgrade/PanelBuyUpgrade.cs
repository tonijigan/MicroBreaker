using Enums;
using PlayerObject;
using TMPro;
using UnityEngine;

public class PanelBuyUpgrade : Panel
{
    [SerializeField] private Panel _backGround;
    [SerializeField] private Wallet _wallet;

    private UpgradeView _upgradeView;

    public override async void Move(bool isAction)
    {
        _backGround.gameObject.SetActive(isAction);
        base.Move(isAction);
        await MovePanel(isAction);
    }

    public void Init(UpgradeView upgradeView, ObjectsName objectsName)
    {
        _upgradeView = upgradeView;
        Debug.Log($"{_upgradeView.Price} / {objectsName}");
    }
}