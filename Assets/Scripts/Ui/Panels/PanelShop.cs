using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PanelShop : Panel
{
    [SerializeField] private ButtonPanelInteraction[] _buttonPanelInteractions;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private Panel _backGroundPanel;
    [SerializeField] private float _topPositionX;
    [SerializeField] private float _tweenDuration;

    public event Action<bool> Activated;
    private RectTransform _rectTransform;

    public bool IsActive { get; private set; } = false;

    public ButtonPanelInteraction ButtenClose => _buttonClose;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _buttonClose.Clicked += Move;
    }

    private void OnDisable()
    {
        _buttonClose.Clicked -= Move;
    }

    public override void Move(bool isActive)
    {
        base.Move(isActive);
        OnMovePanel(isActive);
    }

    public void OnMovePanel(bool isOpen)
    {
        float middlePositionX = 0;
        _buttonClose.gameObject.SetActive(isOpen);
        _backGroundPanel.gameObject.SetActive(isOpen);

        if (isOpen)
        {
            _rectTransform.DOAnchorPosX(middlePositionX, _tweenDuration);
            IsActive = true;
        }
        else
        {
            _rectTransform.DOAnchorPosX(_topPositionX, _tweenDuration);
            IsActive = false;
        }

        Activated?.Invoke(isOpen);
    }
}