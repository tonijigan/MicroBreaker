using System;
using UnityEngine;

namespace PlayerObject
{
    public class Wallet : MonoBehaviour
    {
        private int _coins = 0;

        public event Action<int> Changed;

        public int Coin => _coins;

        public void Init(int coins)
        {
            _coins = coins;
            Changed?.Invoke(_coins);
        }

        public void AddCoin(int coins)
        {
            _coins += coins;
            Changed?.Invoke(_coins);
        }

        public void RemoveCoins(int coins)
        {
            if (_coins < coins) return;
            _coins -= coins;
            Changed?.Invoke(_coins);
        }
    }
}