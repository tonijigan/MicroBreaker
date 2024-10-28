using PlayerObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelWin : Panel
{
    [SerializeField] private SaveService _saveService;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private LocationCreate _locationCreate;

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
        SaveGameProgress();
    }

    private void SaveGameProgress()
    {
        _saveService.SaveCoins(_saveService.Coins + _wallet.Coin);
        List<string> list = _saveService.LocationNames.ToList();
        list.Add(_locationCreate.CurrentLocation.LocationName);
        _saveService.SaveArrayLocationNames(list.ToArray());
    }
}