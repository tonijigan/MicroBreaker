using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class PanelPlayNextScene : Panel
{
    [SerializeField] private RectTransform _buttonPlayRectTransform;
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MoveButton(isActive);
    }

    private async Task MoveButton(bool isActive)
    {
        if (isActive)
            await _buttonPlayRectTransform.DOAnchorPosY(_middlePositionY, _tweenDuration).AsyncWaitForCompletion();
        else
            await _buttonPlayRectTransform.DOAnchorPosY(_topPositionY, _tweenDuration).AsyncWaitForCompletion();
    }
}