using System;
using PlayerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PanelBuyAdditionalImprovement : Panel
    {
        [SerializeField] private Panel _backGround;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private TMP_Text _textPrice;
        [SerializeField] private Image _currentImage;
        [SerializeField] private AdditionalImprovementColection _additionalImprovementColection;
        [SerializeField] private Color _firstColor;

        public event Action<AdditionalImprovement> Buid;


        private AdditionalImprovement _additionalImprovement;

        private void OnEnable() => _buttonBuy.onClick.AddListener(Buy);

        private void OnDisable() => _buttonBuy.onClick.RemoveListener(Buy);

        public override async void Move(bool isAction)
        {
            _backGround.gameObject.SetActive(isAction);
            base.Move(isAction);
            await MovePanel(isAction);
        }

        public void Init(AdditionalImprovement additionalImprovement)
        {
            _additionalImprovement = additionalImprovement;
            SetAccessBuy();
        }

        private void Buy()
        {
            if (_wallet.Coin < _additionalImprovement.Price) return;

            _wallet.RemoveCoins(_additionalImprovement.Price);
            _additionalImprovementColection.SaveAdditionalImprovement(_additionalImprovement);
            Move(false);
            Buid?.Invoke(_additionalImprovement);
        }

        private void SetAccessBuy()
        {
            _currentImage.sprite = _additionalImprovement.Sprite;
            _textPrice.text = _additionalImprovement.Price.ToString();

            if (_wallet.Coin < _additionalImprovement.Price)
            {
                _buttonBuy.image.color = Color.red;
                return;
            }

            _buttonBuy.image.color = _firstColor;
        }
    }
}