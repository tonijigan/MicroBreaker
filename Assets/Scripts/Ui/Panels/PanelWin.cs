using Cinemachine;
using DG.Tweening;
using PlayerObject;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(RectTransform))]
public class PanelWin : Panel
{
    private const int Priority = 2;

    [SerializeField] CinemachineVirtualCamera _virtualEndCamera;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

    private RectTransform _rectTransform;
    private PlayableDirector _playableDirector;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _playableDirector = _virtualEndCamera.gameObject.GetComponent<PlayableDirector>();
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
        _playerInput.SetControl();
        _playableDirector.Play();
        _virtualEndCamera.Priority = Priority;
    }

    private async Task MovePanel(bool isActive)
    {
        if (isActive)
            await _rectTransform.DOAnchorPosY(_topPositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_middlePositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}