using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class PanelShop : Panel
    {
        [SerializeField] private ButtonPanelInteraction _buttonClose;
        [SerializeField] private Panel _backGroundPanel;

        public event Action<bool> Activated;

        public bool IsActive { get; private set; } = false;

        public ButtonPanelInteraction ButtenClose => _buttonClose;

        private void OnEnable() => _buttonClose.Clicked += Move;

        private void OnDisable() => _buttonClose.Clicked -= Move;

        public override void Move(bool isActive)
        {
            base.Move(isActive);
            OnMovePanel(isActive);
        }

        public void OnMovePanel(bool isOpen)
        {
            _buttonClose.gameObject.SetActive(isOpen);
            _backGroundPanel.gameObject.SetActive(isOpen);


            RectTransform.DOAnchorPosX(MiddlePosition, TweenDuration);
            IsActive = true;

            if (isOpen == false)
            {
                RectTransform.DOAnchorPosX(TopPosition, TweenDuration);
                IsActive = false;
            }

            Activated?.Invoke(isOpen);
        }
    }
}