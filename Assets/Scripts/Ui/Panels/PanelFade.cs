using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Image))]
public class PanelFade : MonoBehaviour
{
    private const float Duration = 2;
    private const float MinValueAlpha = 0;
    private const float MaxValueAlpha = 1;

    private CanvasGroup _canvasGroup;
    private Image _image;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
        SetActive(true);
    }

    public void SetActive(bool isActive, TweenCallback tweenCallback = null)
    {
        if (isActive == false)
        {
            _image.raycastTarget = true;
            _canvasGroup.DOFade(MaxValueAlpha, Duration).OnComplete(tweenCallback);
        }
        else
        {
            _canvasGroup.DOFade(MinValueAlpha, Duration).OnComplete(() => { _image.raycastTarget = false; tweenCallback?.Invoke(); });
        }
    }
}