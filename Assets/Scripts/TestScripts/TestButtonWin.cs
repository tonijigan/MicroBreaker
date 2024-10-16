using Enums;
using PlayerObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButtonWin : AbstractButton
{
    [SerializeField] private SaveService _saveService;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private LocationCreate _locationCreate;

    protected override void OnClick()
    {
        Debug.Log("S" + _saveService.Coins);
        Debug.Log("W" + _wallet.Coin);
        _saveService.SaveCoins(_saveService.Coins + _wallet.Coin);

        List<string> list = _saveService.LocationNames.ToList();
        list.Add(_locationCreate.CurrentLocation.LocationName);
        _saveService.SaveArrayLocationNames(list.ToArray());
        SceneManager.LoadScene(ScenesName.ChooseLevel.ToString());
    }
}