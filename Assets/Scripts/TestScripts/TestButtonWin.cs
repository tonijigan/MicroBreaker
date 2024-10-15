using Enums;
using PlayerObject;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButtonWin : AbstractButton
{
    [SerializeField] private SaveService _saveService;
    [SerializeField] private Wallet _wallet;

    protected override void OnClick()
    {
        Debug.Log("S" + _saveService.Coins);
        Debug.Log("W" + _wallet.Coin);
        _saveService.SaveCoins(_saveService.Coins + _wallet.Coin);
        SceneManager.LoadScene(ScenesName.ChooseLevel.ToString());
    }
}