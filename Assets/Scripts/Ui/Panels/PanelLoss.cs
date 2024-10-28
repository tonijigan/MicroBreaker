using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PanelLoss : Panel
{
    [SerializeField] private float _topPositionY;
    [SerializeField] private float _middlePositionY;
    [SerializeField] private float _tweenDuration;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
    }

    private async Task MovePanel(bool isActive)
    {
        if (isActive)
            await _rectTransform.DOAnchorPosY(_topPositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_middlePositionY, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}