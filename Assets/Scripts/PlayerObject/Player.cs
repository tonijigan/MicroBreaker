using BallObject;
using PlatformObject;
using UnityEngine;

namespace PlayerObject
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private BallMovement _ballMovement;
        [SerializeField] private PlatformTrigger _platformTrigger;

        private void OnEnable()
        {
            _ballMovement.BoxTriggered += OnAddCoins;
            _platformTrigger.CoinTriggered += OnAddCoins;
        }

        private void OnDisable()
        {
            _ballMovement.BoxTriggered -= OnAddCoins;
            _platformTrigger.CoinTriggered -= OnAddCoins;
        }

        private void OnAddCoins()
        {
            int coin = 1;
            _wallet.AddCoin(coin);
        }
    }
}