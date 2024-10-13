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
        [SerializeField] private SaveService _saveService;

        private void OnEnable()
        {
            _ballMovement.BoxTriggered += OnAddCoins;
            _platformTrigger.CoinTriggered += OnAddCoins;
            _wallet.Changed += OnSaveCoins;
        }

        private void OnDisable()
        {
            _ballMovement.BoxTriggered -= OnAddCoins;
            _platformTrigger.CoinTriggered -= OnAddCoins;
            _wallet.Changed -= OnSaveCoins;
        }

        private void OnAddCoins()
        {
            _wallet.AddCoin();
        }

        private void OnSaveCoins(int coins)
        {
            _saveService.SaveCoins(coins);
        }
    }
}