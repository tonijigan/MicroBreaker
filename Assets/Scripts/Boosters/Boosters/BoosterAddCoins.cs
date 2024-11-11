using Boosters;
using PlayerObject;
using UnityEngine;

public class BoosterAddCoins : AbstractBooster
{
    private const int Coins = 15;

    [SerializeField] private Wallet _wallet;

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _wallet.AddCoin(Coins);
        boosterEffect.SetActionActive();
    }
}