using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup), typeof(Image))]
public class PanelFade : MonoBehaviour
{
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
            _canvasGroup.DOFade(1, 1f).OnComplete(tweenCallback);
        }
        else
        {
            _canvasGroup.DOFade(0, 2f).OnComplete(() => { _image.raycastTarget = false; tweenCallback?.Invoke(); });
        }
    }
}