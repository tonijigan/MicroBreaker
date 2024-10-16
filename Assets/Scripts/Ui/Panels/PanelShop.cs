using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class PanelShop : Panel
{
    [SerializeField] private ButtonPanelInteraction[] _buttonPanelInteractions;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private Panel _backGroundPanel;
    [SerializeField] private float _topPositionX;
    [SerializeField] private float _tweenDuration;


    public event Action<bool> Actived;
    private RectTransform _rectTransform;
    private Image _image;

    public bool IsActive { get; private set; } = false;

    public ButtonPanelInteraction ButtenClose => _buttonClose;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _buttonPanelInteractions.Length; i++)
        {
            _buttonPanelInteractions[i].Clicked += OnMovePanel;
        }

        _buttonClose.Clicked += OnMovePanel;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonPanelInteractions.Length; i++)
        {
            _buttonPanelInteractions[i].Clicked -= OnMovePanel;
        }

        _buttonClose.Clicked -= OnMovePanel;
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

        Actived?.Invoke(isOpen);
    }
}