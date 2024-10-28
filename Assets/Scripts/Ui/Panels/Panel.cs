using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Panel : MonoBehaviour
{
    [SerializeField] private float _topPosition;
    [SerializeField] private float _middlePosition;
    [SerializeField] private float _tweenDuration;

    public event Action Moved;

    private RectTransform _rectTransform;

    protected RectTransform RectTransform => _rectTransform;

    protected float TopPosition => _topPosition;

    protected float MiddlePosition => _middlePosition;

    protected float TweenDuration => _tweenDuration;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public virtual void Move(bool isAction)
    {
        Moved?.Invoke();
    }

    protected async Task MovePanel(bool isActive)
    {
        if (isActive)
            await _rectTransform.DOAnchorPosY(_topPosition, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_middlePosition, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
    }
}