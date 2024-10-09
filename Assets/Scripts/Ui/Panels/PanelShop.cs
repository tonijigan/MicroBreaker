using DG.Tweening;
using UnityEngine;

public class PanelShop : Panel
{
    [SerializeField] private ButtonPanelInteraction[] _buttonPanelInteractions;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private Panel _backGroundPanel;
    [SerializeField] private float _longMove;
    [SerializeField] private float _moveSpeed;

    private Transform _transform;
    private float _durationOpen;
    private float _durationClose;

    private void Awake()
    {
        _transform = transform;
        _durationOpen = _transform.position.x - _longMove;
        _durationClose = _transform.position.x;
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
        _buttonClose.gameObject.SetActive(isOpen);
        _backGroundPanel.gameObject.SetActive(isOpen);

        if (isOpen)
            _transform.DOMoveX(_durationOpen, _transform.position.x * _moveSpeed * Time.deltaTime);
        else
            _transform.DOMoveX(_durationClose, _transform.position.x * _moveSpeed * Time.deltaTime);
    }
}