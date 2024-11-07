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
    [SerializeField] private bool _isActiveAtStart = false;

    public event Action Moved;

    private RectTransform _rectTransform;

    protected RectTransform RectTransform => _rectTransform;

    protected float TopPosition => _topPosition;

    protected float MiddlePosition => _middlePosition;

    protected float TweenDuration => _tweenDuration;

    private void Awake() => InitAwake();

    public virtual void Move(bool isAction) => Moved?.Invoke();

    protected virtual void InitAwake()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (_isActiveAtStart == true)
            gameObject.SetActive(false);
    }

    protected async Task MovePanel(bool isActive)
    {
        if (isActive == true)
            gameObject.SetActive(isActive);

        if (isActive)
            await _rectTransform.DOAnchorPosY(_topPosition, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        else
            await _rectTransform.DOAnchorPosY(_middlePosition, _tweenDuration).SetUpdate(true).AsyncWaitForCompletion();

        gameObject.SetActive(isActive);
    }
}