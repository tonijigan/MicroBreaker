using PlayerLogic;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterAddCoins : AbstractBooster
    {
        private const int Coins = 15;

        [SerializeField] private Wallet _wallet;

        public override void StopAction(BoosterEffect _) { }

        public override void OnStartAction(BoosterEffect boosterEffect)
        {
            _wallet.AddCoin(Coins);
            boosterEffect.SetActionActive();
        }
    }
}