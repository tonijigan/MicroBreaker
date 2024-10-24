using Cinemachine;
using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private LocationCreateView _locationCreateView;
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

    private RectTransform _rectTransform;

    public bool IsInit { get; private set; }

    public ButtonPanelInteraction ButtonClose => _buttonClose;

    public ButtonPlayGame ButtonPlayGame => _buttonPlayGame;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _buttonPlayGame.Clicked += () => { Move(false); };
    }

    private void OnDisable()
    {
        _buttonPlayGame.Clicked -= () => { Move(false); };
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MoveButton(isActive);
    }

    public void Init(LocationObject locationObject)
    {
        IsInit = false;
        _buttonPlayGame.Init(locationObject);

        if (locationObject.IsActive == true)
            IsInit = true;
    }

    private async Task MoveButton(bool isActive)
    {
        if (isActive)
            await _rectTransform.DOAnchorPosY(_middlePositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_topPositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();

        _locationCreateView.gameObject.SetActive(isActive);
    }
}