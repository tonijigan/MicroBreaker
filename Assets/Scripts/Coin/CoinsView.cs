using PlayerLogic;
using TMPro;
using UnityEngine;

namespace Coin
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textCoins;
        [SerializeField] protected Wallet _wallet;

        private void OnEnable() => _wallet.Changed += OnInit;

        private void OnDisable() => _wallet.Changed -= OnInit;

        private void OnInit(int coins) => _textCoins.text = coins.ToString();
    }
}